namespace ArchitectureTest.Model.Entities;

public class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Age { get; private set; }
    public string City { get; private set; }

    public Person(string name, string lastName, string age, string city)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastName;
        Age = age;
        City = city;
    }

    public void Updated(string name, string lastName, string age, string city)
    {
        Name = name;
        LastName = lastName;
        Age = age;
        City = city;
    }
}
