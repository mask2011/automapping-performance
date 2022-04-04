using MappersBenchmark.Enums;

namespace MappersBenchmark.Models
{
    internal class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public AddressType AddressType { get; set; }
        public City City { get; set; }
    }
}
