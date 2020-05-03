using System.Windows;
using System.Windows.Controls;
using WpfApp1.View.FileExtension;
using WpfApp1.ViewModel;

namespace WpfApp1.Pages.File
{
    /// <summary>
    /// Логика взаимодействия для NewProjectPage.xaml.
    /// </summary>
    public partial class NewProjectPage : Page
    {
        public NewProjectPage(EmployeViewModel employeViewModel)
        {
            InitializeComponent();
            EmployeViewModel = employeViewModel;
            EmployeViewModel.Employees.Clear();
        }

        public EmployeViewModel EmployeViewModel { get; set; }

        private void EmployeeGrid_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = EmployeViewModel.Employees;
            if (EmployeeGrid.Items.Count > 1)
            {
                ButtonSave.Visibility = Visibility.Visible;
                ButtonTreatment.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonSave.Visibility = Visibility.Hidden;
                ButtonTreatment.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DefaultDialogService dialogService = new DefaultDialogService();
            if (dialogService.SaveFileDialog())
            {
                dialogService.ShowMessage("File save!");
                EmployeViewModel.SaveToFile(dialogService.FilePath, EmployeViewModel.Employees);
            }
            else
            {
                dialogService.ShowMessage("Bad!");
            }
        }

        private void ButtonTreatment_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxMaxSalary.Visibility == Visibility.Hidden)
            {
                CheckBoxMaxSalary.Visibility = Visibility.Visible;
                CheckBoxSorting.Visibility = Visibility.Visible;
                CheckBoxAverageSalary.Visibility = Visibility.Visible;
            }
            else
            {
                CheckBoxMaxSalary.Visibility = Visibility.Hidden;
                CheckBoxSorting.Visibility = Visibility.Hidden;
                CheckBoxAverageSalary.Visibility = Visibility.Hidden;
            }
        }

        private void EmployeeGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            if (EmployeeGrid.Items.Count > 1)
            {
                ButtonSave.Visibility = Visibility.Visible;
                ButtonTreatment.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonSave.Visibility = Visibility.Hidden;
                ButtonTreatment.Visibility = Visibility.Hidden;
            }
        }

        private void CheckBoxMaxSalary_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxAverageSalary.IsChecked = false;
            CheckBoxSorting.IsChecked = false;
            if (CheckBoxMaxSalary.IsChecked == true)
            {
                View.DialogService.TreatmentWindow treatmentWindow = new View.DialogService.TreatmentWindow(EmployeViewModel);
                treatmentWindow.Show();
            }
        }

        private void CheckBoxAverageSalary_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxMaxSalary.IsChecked = false;
            CheckBoxSorting.IsChecked = false;
            if (CheckBoxAverageSalary.IsChecked == true)
            {
                View.AverageSalaryWindow averageSalaryWindow = new View.AverageSalaryWindow(EmployeViewModel);
                averageSalaryWindow.Show();
            }
        }

        private void CheckBoxSorting_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxMaxSalary.IsChecked = false;
            CheckBoxAverageSalary.IsChecked = false;
            if (CheckBoxSorting.IsChecked == true)
            {
                View.SortingWindow sortingWindow = new View.SortingWindow(EmployeViewModel);

                sortingWindow.ShowDialog();
            }
        }
    }
}
