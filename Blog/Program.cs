using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
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
        
         ReadUsers(connection);
         ReadRoles(connection);
         // ReadUser(1);
         // CreateUser();
         // UpdateUser();
         // DeleteUser(2);
         
         connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var users = repository.GetAll();
        
        foreach (var user in users)
            Console.WriteLine(user.Name);
    }
    
    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);
        var roles = repository.GetAll();
        
        foreach (var role in roles)
            Console.WriteLine(role.Name);
    }
    
    // public static void ReadUser(int id)
    // {
    //     using var connection = new SqlConnection(ConnectionString);
    //
    //     var user = connection.Get<User>(id); //Pega um usuario
    //     Console.WriteLine(user.Name);
    // }
    // public static void CreateUser()
    // {
    //     var user = new User
    //     {
    //         Name = "Sofia Mendes",
    //         Email = "sofia@sofia.com.br",
    //         password_hash = "HASH",
    //         Bio = "Medica",
    //         Image = "https://",
    //         Slug = "sofia-mendes"
    //     };
    //     
    //     using var connection = new SqlConnection(ConnectionString);
    //
    //     connection.Insert<User>(user); //Salva um usuario
    //     Console.WriteLine("Cadastro realizado com sucesso");
    // }
    // public static void UpdateUser()
    // {
    //     var user = new User
    //     {
    //         Id = 3,
    //         Name = "Sofia Mendes",
    //         Email = "sofia@sofia.com.br",
    //         password_hash = "HASH",
    //         Bio = "Medica | Diretora de Hospital",
    //         Image = "https://",
    //         Slug = "sofia-mendes"
    //     };
    //     
    //     using var connection = new SqlConnection(ConnectionString);
    //
    //     connection.Update<User>(user); //Atualiza um usuario
    //     Console.WriteLine("Atualização realizada com sucesso");
    // }
    // public static void DeleteUser(int id)
    // {
    //     using var connection = new SqlConnection(ConnectionString);
    //     
    //     var user = connection.Get<User>(id);
    //
    //     connection.Delete<User>(user); //Deleta um usuario
    //     Console.WriteLine("Exclusão realizada com sucesso");
    // }
}
