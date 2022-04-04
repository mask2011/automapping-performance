namespace MappersBenchmark.DTOs
{
    internal class JobDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnnualSalary { get; set; }
        public int MonthlySalary { get; set; }
        public DateOnly DateRecruited { get; set; }
    }
}
