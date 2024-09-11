using CrudInWeb.Model;

namespace CrudInWeb.Service;

public interface IPersonService
{
    IEnumerable<Person> GetAllPeople();
    Person? GetPersonById(int id);
    bool AddPerson(Person person);
    bool UpdatePerson(Person person);
    bool DeletePerson(int id);
}