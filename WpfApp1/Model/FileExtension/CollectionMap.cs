using CsvHelper.Configuration;

namespace WpfApp1.View.FileExtension
{
    public class CollectionMap : ClassMap<Employee>
    {
        public CollectionMap()
        {
            Map(m => m.Surname).Name(nameof(Employee.Surname));
            Map(m => m.DepartmentName).Name(nameof(Employee.DepartmentName));
            Map(m => m.Salary).Name(nameof(Employee.Salary));
        }
    }
}
