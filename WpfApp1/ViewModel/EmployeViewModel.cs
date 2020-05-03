using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApp1.View.FileExtension;

namespace WpfApp1.ViewModel
{
    public class EmployeViewModel
    {
        public EmployeViewModel()
        {
            Employees = new ObservableCollection<Employee>();
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public static List<(string, float)> SearchMaxSalaryForDepartament(List<(string, float)> tempItem) => Employee.SearchMaxSalary(tempItem);

        public void SaveToFile(string path, ObservableCollection<Employee> employees)
        {
            FileExtensions.SaveToFile(path, employees);
        }

        public void OpenFile(string path)
        {
            List<Employee> a = FileExtensions.GetFromFile(path).ToList();
            foreach (var item in a)
            {
                Employees.Add(item);
            }
        }

        public (string, float) SearchMaxSalary(Employee employee) => employee.CheckMaxSalaryForHalfYear();

        public (string, float) ShowCheckAverageSalary(Employee employee) => employee.CheckAverageSalaryForHalfYear();

        public List<Employee> SortAverageSalary(List<Employee> temp) => Employee.Sorting(temp);
    }
}
