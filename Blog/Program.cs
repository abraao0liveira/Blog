using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private const string ConnectionString =
        @"Server=localhost,1433;Database=blog_balta;User ID=sa;Password=C3rul3@nC@v3_150;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=true;";
    
    static void Main(string[] args)
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
         ReadUsersWithRoles(connection);
         // ReadRoles(connection);
         // ReadTags(connection);
         // ReadUser(1);
         // CreateUser();
         // UpdateUser();
         // DeleteUser(2);
         
         connection.Close();
    }

    public static void ReadUsersWithRoles(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var items = repository.GetWithRoles();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
            foreach (var role in item.Roles)
            {
                Console.WriteLine($" - {role.Name}");
            }
        }
    }
    
    public static void CreateUser(SqlConnection connection)
    {
        var user = new User
        {
            Name = "Sofia Mendes",
            Email = "sofia@sofia.com.br",
            password_hash = "HASH",
            Bio = "Medica",
            Image = "https://",
            Slug = "sofia-mendes"
        };
        
        var repository = new Repository<User>(connection);
        repository.Create(user);
        
        Console.WriteLine("Cadastro realizado com sucesso");
    }
    
    public static void ReadUser(SqlConnection connection, int id)
    {
        var repository = new Repository<User>(connection);
        var user = repository.Get(id);
        
        Console.WriteLine(user.Name);
    }
    
    public static void UpdateUser(SqlConnection connection)
    {
        var user = new User
        {
            Id = 3,
            Name = "Sofia Mendes",
            Email = "sofia@sofia.com.br",
            password_hash = "HASH",
            Bio = "Medica | Diretora de Hospital",
            Image = "https://",
            Slug = "sofia-mendes"
        };
        
        var repository = new Repository<User>(connection);
        repository.Update(user);
        
        Console.WriteLine("Atualização realizada com sucesso");
    }
    public static void DeleteUser(SqlConnection connection, User user)
    {
        var repository = new Repository<User>(connection);
        repository.Delete(user);
        
        Console.WriteLine("Exclusão realizada com sucesso");
    }
    
    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new Repository<Role>(connection);
        var items = repository.GetAll();
        
        foreach (var item in items)
            Console.WriteLine(item.Name);
    }
    
    public static void ReadTags(SqlConnection connection)
    {
        var repository = new Repository<Tag>(connection);
        var items = repository.GetAll();
        
        foreach (var item in items)
            Console.WriteLine(item.Name);
    }
}
