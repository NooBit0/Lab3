namespace WpfApp1.View.ViewInterface
{
    public interface IDialogService
    {
        string FilePath { get; set; }

        bool OpenFileDialog();

        bool SaveFileDialog();

        void ShowMessage(string message);
    }
}
