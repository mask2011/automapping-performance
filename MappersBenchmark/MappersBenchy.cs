using AutoMapper;
using BenchmarkDotNet.Attributes;
using MappersBenchmark.Automapper;
using MappersBenchmark.DTOs;
using MappersBenchmark.Method;
using MappersBenchmark.Models;
using Mapster;

namespace MappersBenchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MappersBenchy
    {
        List<Person> _persons;
        Person _person;

        IMapper _mapper;

        [GlobalSetup]
        public void Setup()
        {
            _persons = DataSeed.GetPersons(1000);
            _person = DataSeed.GetPerson();

            var config = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AutoMapperMappingProfile()));

            _mapper = config.CreateMapper();
        }

        [Benchmark]
        public void MethodBenchmarkPersons()
        {
            MethodMappingProfile.MapPersons(_persons);
        }

        [Benchmark]
        public void MapsterBenchmarkPersons()
        {
            _persons.Adapt<List<PersonDto>>();
        }

        [Benchmark]
        public void AutoMapperBenchmarkPersons()
        {
            _mapper.Map<List<Person>, List<PersonDto>>(_persons);
        }


        [Benchmark]
        public void MethodBenchmarkPerson()
        {
            MethodMappingProfile.MapPerson(_person);
        }

        [Benchmark]
        public void MapsterBenchmarkPerson()
        {
            _person.Adapt<PersonDto>();
        }

        [Benchmark]
        public void AutoMapperBenchmarkPerson()
        {
            _mapper.Map<Person, PersonDto>(_person);
        }
    }
}
