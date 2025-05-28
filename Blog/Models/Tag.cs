using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[tag]")]
public class Tag
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
}