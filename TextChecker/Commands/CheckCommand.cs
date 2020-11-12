using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TextChecker.ViewModel;

namespace TextChecker.Commands
{
    public class CheckCommand : ICommand
    {
        private ICheckerViewModel checkerViewModel;
        private string input;

        public event EventHandler CanExecuteChanged;

        public ICheckerViewModel CheckerViewModel
        {
            get
            {
                return checkerViewModel;
            }
            set
            {
                if(checkerViewModel != value)
                {
                    if(checkerViewModel != null)
                    {
                        checkerViewModel.PropertyChanged -= this.OnViewModelPropertyChanged;
                    }
                    checkerViewModel = value;
                    checkerViewModel.PropertyChanged += this.OnViewModelPropertyChanged;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(this.CheckerViewModel.TextInput);
        }

        public void Execute(object parameter)
        {
            input = this.CheckerViewModel.TextInput;
            if (input.SequenceEqual(input.Reverse()))
            {
                this.CheckerViewModel.CheckOutput = "Yay! Your input is a palindrome!";
            }
            else
            {
                this.CheckerViewModel.CheckOutput = "Nay! Your input is no palindrome!";
            }
            
        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
