using ArchitectureTest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionString:DataBase"]));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/person", async (ApplicationDbContext dbContext) =>
{
    try
    {
        var data = await dbContext.Person.ToListAsync();
        return Results.Ok(data);
    } catch(Exception ex)
    {
        return Results.BadRequest(ex);
    }
})
.WithName("GetPerson");

app.MapPost("/person", async (Person person, [FromServices] ApplicationDbContext dbContext) =>
{
    try
    {
        var createPerson = await dbContext.Person.AddAsync(person);
        dbContext.SaveChanges();

        return Results.Created("Criado com sucesso!", person);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }


}).WithName("PostPerson");


app.MapPut("/person/{id}", async (Guid id, Person person, [FromServices] ApplicationDbContext dbContext) =>
{
    try
    {
        var existingPerson = dbContext.Person.Find(id);

        if (existingPerson == null)
        {
            throw new Exception("Person não existe!");
        }


        existingPerson.Updated(person.Name, person.LastName, person.Age, person.City);

        dbContext.Update(existingPerson);
        dbContext.SaveChanges();

        return Results.Ok("Alterado com sucesso!");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
}).WithName("PutPerson");

app.MapDelete("/person/{id}", async (Guid id, [FromServices] ApplicationDbContext dbContext) =>
{
    try
    {
        var existingPerson = dbContext.Person.Find(id);
        if (existingPerson == null)
        {
            throw new Exception("Person não existe!");
        }

        dbContext.Remove(existingPerson);
        dbContext.SaveChanges();

        return Results.Ok("Removido com sucesso!");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }

}).WithName("DeletePerson");


app.Run();

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
