using MappersBenchmark.DTOs;
using MappersBenchmark.Models;

namespace MappersBenchmark.Method;

internal static class MethodMappingProfile
{
    public static PersonDto MapPerson(Person person)
    {
        var personDto = new PersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
            NumberOfChildren = person.NumberOfChildren,
            IsMarried = person.IsMarried,
            IsWorking = person.IsWorking,
            Height = person.Height,
            Job = new JobDto
            {
                Id = person.Job.Id,
                Name = person.Job.Name,
                AnnualSalary = person.Job.AnnualSalary,
                MonthlySalary = person.Job.MonthlySalary,
                DateRecruited = person.Job.DateRecruited
            }
        };

        personDto.Telephones = new List<TelephoneDto>();
        person.Telephones.ForEach(telephone =>
        {
            var telephoneDto = new TelephoneDto
            {
                Id = telephone.Id,
                Number = telephone.Number,
                TelephoneType = telephone.TelephoneType
            };

            personDto.Telephones.Add(telephoneDto);
        });

        personDto.Adresses = new List<AddressDto>();
        person.Adresses.ForEach(address =>
        {
            var addressDto = new AddressDto
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                ZipCode = address.ZipCode,
                AddressType = address.AddressType,
                City = new CityDto
                {
                    Id = address.City.Id,
                    Name = address.City.Name,
                }
            };

            personDto.Adresses.Add(addressDto);
        });

        personDto.Emails = new List<EmailDto>();
        person.Emails.ForEach(email =>
        {
            var emailDto = new EmailDto
            {
                Id = email.Id,
                EmailAddress = email.EmailAddress,
            };

            personDto.Emails.Add(emailDto);
        });

        return personDto;
    }

    public static List<PersonDto> MapPersons(List<Person> persons)
    {
        var result = new List<PersonDto>();

        persons.ForEach(person =>
        {
            var personDto = MapPerson(person);

            result.Add(personDto);
        });

        return result;
    }
}
