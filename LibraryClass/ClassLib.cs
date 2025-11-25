namespace ReferenceLibraryClass
{
    public class EmployeeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsVeteran { get; set; }

    }

    public interface IEmployeeDataReader
    {
        EmployeeRecord GetEmployeeRecord(int empId);
    }

    public class MockEmployeeDataReader : IEmployeeDataReader
    {
        public EmployeeRecord GetEmployeeRecord(int empId)
        {
            return empId switch
            {
                101 => new EmployeeRecord { Id = 101, Name = "Ramya", Role = "Intern", IsVeteran = false },
                102 => new EmployeeRecord { Id = 102, Name = "Keerti", Role = "Developer", IsVeteran = false },
                103 => new EmployeeRecord { Id = 103, Name = "Chiru", Role = "Manager", IsVeteran = true },
                104 => new EmployeeRecord { Id = 104, Name = "Balaji", Role = "Manager", IsVeteran = false },
                _ => new EmployeeRecord { Id = empId, Name = "Unknown", Role = "Contractor", IsVeteran = false }
            };

        }
    }

    public class PayrollProcessor
    {
        private readonly IEmployeeDataReader _dataReader;

        

        public PayrollProcessor(IEmployeeDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        private static readonly Dictionary<int, decimal> BaseSalaries = new Dictionary<int, decimal>
        {
            [101] = 65000m,
            [102] = 120000m,
            [103] = 50000m,
            [104] = 40000m,


        };
        public decimal CalculateTotalCompensation(int empId)
        {
            var record = _dataReader.GetEmployeeRecord(empId);

            decimal baseSalary = BaseSalaries.TryGetValue(empId, out var s) ? s : 0m;

            decimal bonus = record switch
            {
                { Role: "Manager", IsVeteran: true } => 10000m,
                { Role: "Manager", IsVeteran: false } => 5000m,
                { Role: "Developer" } => 2000m,
                { Role: "Intern" } => 500m,
                _ => 0m
            };

            return baseSalary + bonus;
        }
    }
}
