using ArchitectureTest.Model.Entities;

namespace ArchitectureTest.Services.Interfaces;

public interface IPersonService
{
    Task<List<Person>> GetPerson();
    Task CreatePerson(Person person);
    Task UpdatePerson(Guid id, Person person);
    Task DeletePerson(Guid id);
}
