using System.Collections.Generic;
using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1.View.DialogService
{
    /// <summary>
    /// Логика взаимодействия для TreatmentWindow.xaml
    /// </summary>
    public partial class TreatmentWindow : Window
    {
        public TreatmentWindow(EmployeViewModel employeViewModel)
        {
            InitializeComponent();
            EmployeViewModel = employeViewModel;
        }

        public EmployeViewModel EmployeViewModel { get; set; }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var tempItem = new List<(string, float)>();
            foreach (var item in EmployeViewModel.Employees)
            {
                tempItem.Add(EmployeViewModel.SearchMaxSalary(item));
            }

            foreach (var item in EmployeViewModel.SearchMaxSalaryForDepartament(tempItem))
            {
                Text.Inlines.Add(item.Item1 + '\t' + item.Item2 + '\n');
            }
        }
    }
}
