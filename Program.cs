using DeShawns.Models;
using DeShawns.Models.DTOs;

List<Walker> walkers = new List<Walker>
{
    new Walker()
    {
        Id = 1,
        Name = "Sarah",
        DogId = 1
    },
    new Walker()
    {
        Id = 1,
        Name = "Mike",
        DogId = 2
    },
    new Walker()
    {
        Id = 1,
        Name = "Emily",
        DogId = 3
    },
    new Walker()
    {
        Id = 1,
        Name = "Jason",
        DogId = 4
    },
    new Walker()
    {
        Id = 1,
        Name = "Olivia",
        DogId = 5 
    }
};

List<Dog> dogs = new List<Dog>
{
    new Dog()
    {
        Id = 1,
        Name = "Bailey",
        WalkerId = 1,
        CityId = 1
    },
     new Dog()
    {
        Id = 2,
        Name = "Max",
        WalkerId = 2,
        CityId = 2
    },
     new Dog()
    {
        Id = 3,
        Name = "Luna",
        WalkerId = 3,
        CityId = 3
    },
     new Dog()
    {
        Id = 4,
        Name = "Charlie",
        WalkerId = 4,
        CityId = 4
    },
     new Dog()
    {
        Id = 1,
        Name = "Daisy",
        WalkerId = 5,
        CityId = 5
    },
     new Dog()
    {
        Id = 1,
        Name = "Rocky",
        WalkerId = 1,
        CityId = 6
    },
     new Dog()
    {
        Id = 1,
        Name = "Bella",
        WalkerId = 2,
        CityId = 7
    },
     new Dog()
    {
        Id = 1,
        Name = "Cooper",
        WalkerId = 3,
        CityId = 8
    },
     new Dog()
    {
        Id = 1,
        Name = "Lucy",
        WalkerId = 4,
        CityId = 9
    },
     new Dog()
    {
        Id = 1,
        Name = "Buddy",
        WalkerId = 5,
        CityId = 10
    },
};

List<City> cities = new List<City>
{
    new City()
    {
        Id = 1,
        Name = "New York City"
    },
     new City()
    {
        Id = 2,
        Name = "LA"
    },
     new City()
    {
        Id = 3,
        Name = "Chicago"
    },
     new City()
    {
        Id = 4,
        Name = "Charlotte"
    },
     new City()
    {
        Id = 5,
        Name = "Denver"
    },
     new City()
    {
        Id = 6,
        Name = "Houston"
    },
     new City()
    {
        Id = 7,
        Name = "Phoenix"
    },
     new City()
    {
        Id = 8,
        Name = "Philly"
    },
     new City()
    {
        Id = 9,
        Name = "Dallas"
    },
     new City()
    {
        Id = 10,
        Name = "Murfreesboro"
    }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/hello", () =>
{
    return new { Message = "Welcome to DeShawn's Dog Walking" };
});

app.MapGet("/api/dogs", () =>
{
    foreach (Dog dog in dogs) 
    {
        dog.City = cities.FirstOrDefault(c => c.Id == dog.CityId);
    }
    return dogs.Select(d => new DogDTO
    {
        Id = d.Id,
        Name = d.Name,
        CityId = d.CityId,
        WalkerId = d.WalkerId,
        City = new CityDTO 
        {
            Id = d.City.Id,
            Name = d.City.Name
        }
    });
});


app.Run();
