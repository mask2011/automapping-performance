using AutoMapper;

using MappersBenchmark.Automapper;
using MappersBenchmark.DTOs;
using MappersBenchmark.Mapperly;
using MappersBenchmark.Method;
using MappersBenchmark.Models;

using Mapster;

using System.Diagnostics;

namespace MappersBenchmark;

public class MappersDebug
{
    List<Person> _persons;
    List<PersonDto> _personDtos;
    Person _person;
    PersonDto _personDto;
    IMapper _mapper;
    Stopwatch _stopwatch;

    public MappersDebug()
    {
        _persons = DataSeed.GetPersons(1000);
        _person = DataSeed.GetPerson();

        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile(new AutoMapperMappingProfile()));

        _mapper = config.CreateMapper();

        _stopwatch = new Stopwatch();
    }

    public void MapPersons(string methodType)
    {
        Console.WriteLine($"Method Type: {methodType}");

        _stopwatch.Start();

        _personDtos = methodType switch
        {
            "Method" => MethodPersons(_persons),
            "Mapster" => MapsterPersons(_persons),
            "AutoMapper" => AutoMapperPersons(_persons),
            "Mapperly" => MapperlyPersons(_persons),
            _ => throw new Exception("Wrong Method")
        };

        _stopwatch.Stop();

        Console.WriteLine($"Time elapsed: {_stopwatch.Elapsed}");
        Console.WriteLine("Press Enter...");

        Console.ReadLine();
    }

    public void MapPerson(string methodType)
    {
        Console.WriteLine($"Method Type: {methodType}");

        _stopwatch.Start();

        _personDto = methodType switch
        {
            "Method" => MethodPerson(_person),
            "Mapster" => MapsterPerson(_person),
            "AutoMapper" => AutoMapperPerson(_person),
            "Mapperly" => MapperlyPerson(_person),
            _ => throw new Exception("Wrong Method")
        };

        _stopwatch.Stop();

        Console.WriteLine($"Time elapsed: {_stopwatch.Elapsed}");
        Console.WriteLine("Press Enter...");

        Console.ReadLine();
    }

    List<PersonDto> MethodPersons(List<Person> persons)
    {
        return MethodMappingProfile.MapPersons(persons);
    }

    List<PersonDto> MapsterPersons(List<Person> persons)
    {
        return persons.Adapt<List<PersonDto>>();
    }

    List<PersonDto> AutoMapperPersons(List<Person> persons)
    {
        return _mapper.Map<List<Person>, List<PersonDto>>(_persons);
    }

    List<PersonDto> MapperlyPersons(List<Person> persons)
    {
        return PersonMapper.MapPersonsToPersonDtos(_persons);
    }

    PersonDto MethodPerson(Person person)
    {
        return MethodMappingProfile.MapPerson(person);
    }

    PersonDto MapsterPerson(Person person)
    {
        return person.Adapt<PersonDto>();
    }

    PersonDto AutoMapperPerson(Person person)
    {
        return _mapper.Map<Person, PersonDto>(_person);
    }

    PersonDto MapperlyPerson(Person person)
    {
        return PersonMapper.MapPersonToPersonDto(_person);
    }
}
