using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[user]")]
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string password_hash { get; set; }
    public required string Bio { get; set; }
    public required string Image { get; set; }
    public required string Slug { get; set; }
}
