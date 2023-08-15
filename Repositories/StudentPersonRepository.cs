using ArchitectureTest.Model.DTOs;
using ArchitectureTest.Model.Entities;
using ArchitectureTest.Repositories.Interfaces;

namespace ArchitectureTest.Repositories;

public class StudentPersonRepository : IStudentPersonRepository
{
    public Task Created(Person person)
    {
        throw new NotImplementedException();
    }

    public Task Deleted(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StudentPersonView>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<StudentPersonView> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Updated(Guid id, Person person)
    {
        throw new NotImplementedException();
    }
}
