using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _tokenEndpoint;
    private string _accessToken;
    private DateTime _tokenExpirationTime;

    public ApiClient(string clientId, string clientSecret, string tokenEndpoint, string apiBaseUrl)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _tokenEndpoint = tokenEndpoint;
        _httpClient = new HttpClient
        //!диспозабл
        {
            BaseAddress = new Uri(apiBaseUrl)
            //класс, представляющий URI, >><<  нуу, можно его по частям запросить, узнать схемы-мемы...
        };
    }

    private async Task<(string token, int expiresIn)> GetAccessTokenAsync()
    {
        var authString = Convert.ToBase64String(
            Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
        //стандартный формат Basic Authentication, определенный в RFC 7617. Называется "Basic Authentication Encoding" или "Base64 Credentials Encoding"

        var tokenRequest = new HttpRequestMessage(HttpMethod.Post, _tokenEndpoint)
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            //для отправки Form-Data  - application/x-www-form-urlencoded
            //в постмане такое есть. наряду с Raw/Json 
            //для Raw/Json - использовать, вроде, JsonContent
            {
                {"grant_type", "client_credentials"}
                //прописано в спецификации OAuth2 - мы говорим, что хотим авторизоваться
                //через, вот, передачу ~логина-пароля
            })
        };

        tokenRequest.Headers.Authorization =
            new AuthenticationHeaderValue("Basic", authString);
        //нуу, в стандарте HTTP упомянут заголовок Authorization. вот, это будет сгенерен он.
        //"Basic" - тип авторизации, который мы используем (он должен быть ожидаем на той стороне, я так понимаю)

        var response = await _httpClient.SendAsync(tokenRequest);
        //сделали запрос

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);

        return (
            token: tokenResponse.AccessToken,
            expiresIn: tokenResponse.ExpiresIn  //так то это - необязательное значение, надо предусматривать
        );
    }

    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        //ключи тоже прописаны в стандарте OAuth2
    }

    private async Task EnsureValidTokenAsync()
    {
        // Если токен отсутствует или истекает в ближайшие 30 секунд
        if (string.IsNullOrEmpty(_accessToken) ||
            DateTime.UtcNow.AddSeconds(30) >= _tokenExpirationTime)
        {
            var (token, expiresIn) = await GetAccessTokenAsync();
            _accessToken = token;
            _tokenExpirationTime = DateTime.UtcNow.AddSeconds(expiresIn);
        }
    }

    public async Task<string> MakeAuthenticatedRequestAsync(
        string endpoint,
        HttpMethod method = null,
        int retryCount = 1)
    {
        await EnsureValidTokenAsync();

        var request = new HttpRequestMessage(method ?? HttpMethod.Get, endpoint);
        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", _accessToken);

        try
        {
            var response = await _httpClient.SendAsync(request);

            // Если получили 401, пробуем обновить токен и повторить запрос
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                && retryCount > 0)
            {
                _accessToken = null; // Сбрасываем текущий токен
                return await MakeAuthenticatedRequestAsync(
                    endpoint,
                    method,
                    retryCount - 1
                );
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            throw new ApiException(
                $"Request to {endpoint} failed: {ex.Message}",
                ex
            );
        }
    }
}

public class ApiException : Exception
{
    public ApiException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}