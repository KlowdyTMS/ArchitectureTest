using ArchitectureTest.Model.DTOs;
using ArchitectureTest.Model.Entities;

namespace ArchitectureTest.Repositories.Interfaces
{
    public interface IGenericPersonRepository
    {
        Task<IEnumerable<StudentPersonView>> GetAll();
        Task<StudentPersonView> GetById(Guid id);
        Task Created(Person person);
        Task Updated(Guid id, Person person);
        Task Deleted(Guid id);
    }
}
