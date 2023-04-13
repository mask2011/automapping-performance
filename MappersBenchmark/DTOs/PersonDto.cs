namespace MappersBenchmark.DTOs;

internal class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int NumberOfChildren { get; set; }
    public bool IsMarried { get; set; }
    public bool IsWorking { get; set; }
    public decimal Height { get; set; }

    public JobDto Job { get; set; }

    public List<TelephoneDto> Telephones { get; set; }
    public List<AddressDto> Adresses { get; set; }
    public List<EmailDto> Emails { get; set; }
}
