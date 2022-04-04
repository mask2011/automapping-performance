using AutoMapper;
using MappersBenchmark.DTOs;
using MappersBenchmark.Models;

namespace MappersBenchmark.Automapper
{
    internal class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Telephone, TelephoneDto>().ReverseMap();
        }
    }
}
