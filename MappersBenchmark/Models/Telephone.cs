using MappersBenchmark.Enums;

namespace MappersBenchmark.Models
{
    internal class Telephone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public TelephoneType TelephoneType { get; set; }
    }
}
