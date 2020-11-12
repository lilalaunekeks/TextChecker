using TextChecker.Model;
using TextChecker.ViewModel;
using TextChecker.Views;

namespace TextChecker
{
    class ViewInfrastructure
    {
        public CheckerView CheckerView { get; private set; }
        public CheckerViewModel CheckerViewModel { get; private set; }
        public CheckerModel CheckerModel { get; private set; }
        public ViewInfrastructure(CheckerView view, CheckerViewModel viewModel, CheckerModel model)
        {
            this.CheckerView = view;
            this.CheckerViewModel = viewModel;
            this.CheckerModel = model;
        }

    }
}
