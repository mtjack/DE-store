using System.Text.Json.Serialization;

namespace DE_Store_Backend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string userRole { get; set; }
    public string PasswordHash { get; set; }    
    public int StoreId { get; set; }
    public Store Store { get; set; }

}
