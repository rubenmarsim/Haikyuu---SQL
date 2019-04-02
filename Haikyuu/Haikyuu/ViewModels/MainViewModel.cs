using Haikyuu.Services.Navigation;
using Haikyuu.ViewModels.Base;
using System.Windows.Input;

namespace Haikyuu.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _customCellCommand;

        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand CustomCellCommand
        {
            get { return _customCellCommand = _customCellCommand ?? new DelegateCommand(CustomCellCommandExecute); }
        }
        private void CustomCellCommandExecute()
        {
            _navigationService.NavigateTo<CustomCellViewModel>();
        }
    }
}
