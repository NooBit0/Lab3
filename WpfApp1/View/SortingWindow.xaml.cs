using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для SortingWindow.xaml
    /// </summary>
    public partial class SortingWindow : Window
    {
        public SortingWindow(EmployeViewModel employeViewModel)
        {
            InitializeComponent();
            EmployeViewModel = employeViewModel;
        }

        public EmployeViewModel EmployeViewModel { get; set; }

        private void EmployeeGrid_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = EmployeViewModel.SortAverageSalary(EmployeViewModel.Employees.ToList());
        }
    }
}
