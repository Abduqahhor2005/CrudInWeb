using CrudInWeb.Model;
using Dapper;
using Npgsql;

namespace CrudInWeb.Service;

public class PersonService : IPersonService
{
    public IEnumerable<Person> GetAllPeople()
    {
        try
        {
            using (NpgsqlConnection con = new(SqlCommands.ConnectionString))
            {
                con.Open();
                return con.Query<Person>(SqlCommands.GetAllPeople);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Person? GetPersonById(int id)
    {
        try
        {
            using (NpgsqlConnection con = new(SqlCommands.ConnectionString))
            {
                con.Open();
                return con.QueryFirstOrDefault<Person>(SqlCommands.GetPersonById, new{Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool AddPerson(Person person)
    {
        try
        {
            using (NpgsqlConnection con = new(SqlCommands.ConnectionString))
            {
                con.Open();
                return con.Execute(SqlCommands.AddPerson,person) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdatePerson(Person person)
    {
        try
        {
            using (NpgsqlConnection con = new(SqlCommands.ConnectionString))
            {
                con.Open();
                return con.Execute(SqlCommands.UpdatePerson,person) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeletePerson(int id)
    {
        try
        {
            using (NpgsqlConnection con = new(SqlCommands.ConnectionString))
            {
                con.Open();
                return con.Execute(SqlCommands.DeletePerson,new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommands
{
    public const string ConnectionString = "Host=localhost;Database=web_db;User Id=postgres;Port=4321;Password=salom;";
    public const string GetAllPeople = "select * from people";
    public const string GetPersonById = "select * from people where id=@id";
    public const string AddPerson = "insert into people(name) values(@name)";
    public const string UpdatePerson = "update people set name=@name where id=@id";
    public const string DeletePerson = "delete from people where id = @id";
}