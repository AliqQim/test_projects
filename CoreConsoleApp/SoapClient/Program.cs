using ServiceReference1;

await using var client = new ProfileServiceClient();
var profile = await client.GetProfileAsync(1);


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
