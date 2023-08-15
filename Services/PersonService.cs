using ArchitectureTest.Model.Entities;
using ArchitectureTest.Services.Interfaces;

namespace ArchitectureTest.Services;

public class PersonService : IPersonService
{
    public Task CreatePerson(Person person)
    {
        throw new NotImplementedException();
    }

    public Task DeletePerson(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>> GetPerson()
    {
        throw new NotImplementedException();
    }

    public Task UpdatePerson(Guid id, Person person)
    {
        throw new NotImplementedException();
    }
}
