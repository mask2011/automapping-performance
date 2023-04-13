using Bogus;

using MappersBenchmark.Enums;
using MappersBenchmark.Models;

namespace MappersBenchmark;

internal static class DataSeed
{
    public static Models.Person GetPerson()
    {
        return GetPersonFromBogus();
    }

    public static List<Models.Person> GetPersons(int numberOfPersons)
    {
        var persons = new List<Models.Person>();

        for (int i = 0; i < numberOfPersons; i++)
        {
            persons.Add(GetPersonFromBogus());
        }

        return persons;
    }

    private static Models.Person GetPersonFromBogus()
    {
        var jobFaker = new Faker<Job>();
        var telephoneFaker = new Faker<Telephone>();
        var cityFaker = new Faker<City>();
        var addressFaker = new Faker<Address>();
        var emailFaker = new Faker<Email>();

        var personFaker = new Faker<Models.Person>();

        jobFaker
            .RuleFor(j => j.Id, (f, j) => f.Random.Int())
            .RuleFor(j => j.Name, (f, j) => f.Name.JobType());

        var job = jobFaker.Generate();

        telephoneFaker
            .RuleFor(t => t.Id, (f, t) => f.Random.Int())
            .RuleFor(t => t.Number, (f, t) => f.Random.Long().ToString())
            .RuleFor(t => t.TelephoneType, (f, t) => f.PickRandom<TelephoneType>());

        var telephones = telephoneFaker.Generate(10);

        cityFaker
            .RuleFor(c => c.Id, (f, c) => f.Random.Int())
            .RuleFor(c => c.Name, (f, c) => f.Address.City());

        var city = cityFaker.Generate();

        addressFaker
            .RuleFor(a => a.Id, (f, a) => f.Random.Int())
            .RuleFor(a => a.Street, (f, a) => f.Address.StreetName())
            .RuleFor(a => a.Number, (f, a) => f.Address.BuildingNumber())
            .RuleFor(a => a.ZipCode, (f, a) => f.Address.ZipCode())
            .RuleFor(a => a.AddressType, (f, a) => f.PickRandom<AddressType>())
            .RuleFor(a => a.City, _ => city);

        var addresses = addressFaker.Generate(30);


        emailFaker
            .RuleFor(e => e.Id, (f, e) => f.Random.Int())
            .RuleFor(e => e.EmailAddress, (f, e) => f.Internet.Email());

        var emails = emailFaker.Generate(50);

        personFaker
            .RuleFor(p => p.Id, (f, p) => f.Random.Int())
            .RuleFor(p => p.FirstName, (f, p) => f.Person.FirstName)
            .RuleFor(p => p.LastName, (f, p) => f.Person.LastName)
            .RuleFor(p => p.DateOfBirth, (f, p) => f.Date.PastDateOnly())
            .RuleFor(p => p.NumberOfChildren, (f, p) => f.Random.Int())
            .RuleFor(p => p.IsMarried, (f, p) => f.Random.Bool())
            .RuleFor(p => p.IsWorking, (f, p) => f.Random.Bool())
            .RuleFor(p => p.Height, (f, p) => f.Random.Decimal())
            .RuleFor(p => p.Job, (f, p) => job);

        var person = personFaker.Generate();


        person.Telephones = telephones;
        person.Adresses = addresses;
        person.Emails = emails;

        return person;
    }
}
