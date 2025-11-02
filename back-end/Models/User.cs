using back_end.Models.Entity;

namespace back_end.Models;

public class User : BaseEntity
{
    public string FirstName { get; set;}

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set;}
    public string Role { get; set; } = "User";


}
