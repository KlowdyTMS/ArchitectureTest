using ArchitectureTest.Infra;
using ArchitectureTest.Model.DTOs;
using ArchitectureTest.Model.Entities;
using ArchitectureTest.Repositories.Interfaces;
using AutoMapper;

namespace ArchitectureTest.Repositories;

public class GenericPerson : IGenericPersonRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GenericPerson(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Created(Person person)
    {
        _context.Person.Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task Deleted(Guid id)
    {
        var person = await _context.Person.FindAsync(id);

        if (person != null)
        {
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<StudentPersonView>> GetAll()
    {
        var persons = await _context.FindAsync<Person>();
        var studentPersons = _mapper.Map<IEnumerable<StudentPersonView>>(persons);

        return studentPersons;
    }

    public async Task<StudentPersonView> GetById(Guid id)
    {
        var persons = await _context.Person.FindAsync(id);
        StudentPersonView studentPersons = _mapper.Map<StudentPersonView>(persons);

        return studentPersons;
    }

    public async Task Updated(Guid id, Person person)
    {
        var personDb = await _context.Person.FindAsync(id);

        if(personDb != null)
        {
            personDb.Updated(person.Name, person.LastName, person.Age, person.City);
            _context.Person.Update(person);
            await _context.SaveChangesAsync();

        }
    }
}
