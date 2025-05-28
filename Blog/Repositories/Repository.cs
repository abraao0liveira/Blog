using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<T> where T : class //aceita apenas tipos que sao classes
{
    private readonly SqlConnection _connection;
    
    //obs: o '=>' seria o 'return' em um metodo com apenas uma linha
    public Repository(SqlConnection connection)
        => _connection = connection;
    
    public IEnumerable<T> GetAll()
        => _connection.GetAll<T>(); //pega todos os dados da tabela
    
    public T Get(int id)
        => _connection.Get<T>(id); //Pega apenas um dado pelo id

    public void Create(T model)
       => _connection.Insert<T>(model); //Cria um dado

    public void Update(T model)
           => _connection.Update<T>(model); //Atualiza um dado

    public void Delete(T model)
           => _connection.Delete<T>(model); //Deleta um dado

    public void Delete(int id)
    {
        var mode = _connection.Get<T>(id);
        _connection.Delete<T>(mode);
    }
}