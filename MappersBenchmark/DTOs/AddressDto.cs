using MappersBenchmark.Enums;

namespace MappersBenchmark.DTOs;

internal class AddressDto
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string ZipCode { get; set; }
    public AddressType AddressType { get; set; }
    public CityDto City { get; set; }
}
