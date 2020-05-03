using System.Windows;
using System.Windows.Controls;
using WpfApp1.Pages.File;
using WpfApp1.View;
using WpfApp1.View.DialogService;
using WpfApp1.View.FileExtension;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmployeViewModel = new EmployeViewModel();
        }

        public EmployeViewModel EmployeViewModel { get; set; }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new NewProjectPage(EmployeViewModel));
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new OpenProjectPage(EmployeViewModel));
        }

        private void SaveProject_Click(object sender, RoutedEventArgs e)
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MaxSalaryItem_Click(object sender, RoutedEventArgs e)
        {
            TreatmentWindow treatmentWindow = new TreatmentWindow(EmployeViewModel);
            treatmentWindow.Show();
        }

        private void AverageSalaryItem_Click(object sender, RoutedEventArgs e)
        {
            AverageSalaryWindow averageSalaryWindow = new AverageSalaryWindow(EmployeViewModel);
            averageSalaryWindow.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SortingItem_Click(object sender, RoutedEventArgs e)
        {
            View.SortingWindow sortingWindow = new View.SortingWindow(EmployeViewModel);
            sortingWindow.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
