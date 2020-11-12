using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TextChecker.Model;

namespace TextChecker.ViewModel
{
    public class CheckerViewModel : INotifyPropertyChanged, ICheckerViewModel
    {
        private readonly CheckerModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        public string TextInput
        {
            get
            {
                return this.model.TextInput;
            }

            set
            {
                if (this.model.TextInput != value)
                {
                    this.model.TextInput = value;
                    this.CheckOutput = "";
                    this.OnPropertyChanged("TextInput");
                }
            }
        }

        public string CheckOutput
        {
            get
            {
                return this.model.CheckOutput;
            }

            set
            {
                if (this.model.CheckOutput != value)
                {
                    this.model.CheckOutput = value;
                    this.OnPropertyChanged("CheckOutput");
                }
            }
        }

        public ICommand CheckCommand { get; private set; }

        public CheckerViewModel(CheckerModel model, ICommand checkCommand)
        {
            this.model = model;
            this.CheckCommand = checkCommand;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
