using MappersBenchmark.Enums;

namespace MappersBenchmark.DTOs

{
    internal class TelephoneDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public TelephoneType TelephoneType { get; set; }
    }
}
