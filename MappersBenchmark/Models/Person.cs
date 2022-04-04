namespace MappersBenchmark.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int NumberOfChildren { get; set; }
        public bool IsMarried { get; set; }
        public bool IsWorking { get; set; }
        public decimal Height { get; set; }

        public Job Job { get; set; }

        public List<Telephone> Telephones { get; set; }
        public List<Address> Adresses { get; set; }
        public List<Email> Emails { get; set; }
    }
}
