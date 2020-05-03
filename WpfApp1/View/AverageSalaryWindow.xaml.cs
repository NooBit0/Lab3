using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для AverageSalaryWindow.xaml
    /// </summary>
    public partial class AverageSalaryWindow : Window
    {
        public AverageSalaryWindow(EmployeViewModel employeViewModel)
        {
            InitializeComponent();
            EmployeViewModel = employeViewModel;
        }

        public EmployeViewModel EmployeViewModel { get; set; }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Text.Inlines.Clear();
            foreach (var item in EmployeViewModel.Employees)
            {
                if (item.DepartmentName == InputextBox.Text)
                {
                    var temp = EmployeViewModel.ShowCheckAverageSalary(item);
                    Text.Inlines.Add(temp.Item1 + '\t' + temp.Item2 + '\n');
                }
            }
        }
    }
}
