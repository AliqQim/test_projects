namespace aliksoft.AdminWebApp.Models
{
    //TODO or should it's name follow name of its action?
    public class UserItemViewModel
    {
        public string Email { get; init; } = null!;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
