using CrudInWeb.Model;
using CrudInWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace CrudInWeb.Controller;
[Route("Person")]
[ApiController]
public class PersonCategory
{
    private readonly IPersonService _personService = new PersonService();

    [HttpGet]
    public IEnumerable<Person> GetAllPeople()
    {
        return _personService.GetAllPeople();
    }

    [HttpGet("{id}")]
    public Person? GetPersonById(int id)
    {
        return _personService.GetPersonById(id);
    }

    [HttpPost]
    public bool AddPerson(Person person)
    {
        return _personService.AddPerson(person);
    }

    [HttpPut]
    public bool UpdatePerson(Person person)
    {
        return _personService.UpdatePerson(person);
    }

    [HttpDelete]
    public bool DeletePerson(int id)
    {
        return _personService.DeletePerson(id);
    }
}