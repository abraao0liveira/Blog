using System.Text;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository : Repository<User>
{
    private readonly SqlConnection _connection;
    public UserRepository(SqlConnection connection) : base(connection) //chama o ctor da classe base que herdamos
       => _connection = connection;

    public List<User> GetWithRoles()
    {
        var query = new StringBuilder()
            .Append(" select u.*, r.* ")
            .Append(" from [user] [u] ")
            .Append(" left join [user_role] [ur] on [ur].[user_id] = [u].[id] ")
            .Append(" left join [role] [r] on [ur].[role_id] = [r].[id] ")
            .ToString();
        
        var users = new List<User>();
        //many to many
        var items = _connection.Query<User, Role, User>(
            query,
            (user, role) =>
            {
                var usr = users.FirstOrDefault(u => u.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    
                    if (role != null)
                        usr.Roles.Add(role);
                    
                    users.Add(usr);
                }
                else
                {
                    usr.Roles.Add(role);
                }
                return user;
            }, splitOn: "id");
        return users;
    }
}
