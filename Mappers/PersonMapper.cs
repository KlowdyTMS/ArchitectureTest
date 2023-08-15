using ArchitectureTest.Model.DTOs;
using ArchitectureTest.Model.Entities;
using AutoMapper;

namespace ArchitectureTest.Mappers;

public class PersonMapper: Profile
{
    public PersonMapper()
    {
        CreateMap<Person, StudentPersonView>();
    }
}
