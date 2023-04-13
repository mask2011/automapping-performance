using MappersBenchmark.DTOs;
using MappersBenchmark.Models;

using Riok.Mapperly.Abstractions;

namespace MappersBenchmark.Mapperly;

[Mapper]
internal static partial class PersonMapper
{
    public static partial PersonDto MapPersonToPersonDto(Person person);

    public static partial List<PersonDto> MapPersonsToPersonDtos(
        IEnumerable<Person> persons);
}
