using TextChecker.Commands;
using TextChecker.Model;
using TextChecker.ViewModel;
using TextChecker.Views;

namespace TextChecker
{
    class ViewFactory
    {
        public ViewInfrastructure Create()
        {
            CheckCommand checkCommand = new CheckCommand();
            CheckerModel model = new CheckerModel();
            CheckerViewModel viewModel = new CheckerViewModel(model, checkCommand);
            CheckerView view = new CheckerView();

            checkCommand.CheckerViewModel = viewModel;

            return new ViewInfrastructure(view, viewModel, model);
        }
    }
}
