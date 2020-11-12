using System.ComponentModel;

namespace TextChecker.ViewModel
{
    public interface ICheckerViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        string TextInput { get; }
        string CheckOutput { get; set; }
    }
}
