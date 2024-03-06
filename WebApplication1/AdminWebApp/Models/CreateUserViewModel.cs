namespace aliksoft.AdminWebApp.Models
{
    public class CreateUserViewModel
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";

        //TODO make it local enum
        public string Role { get; set; } = "";
    }
}
