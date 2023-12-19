using ModernUi.WPF.Services.Interfaces;
using ModernUi.WPF.ViewModel;
using System.Windows.Input;

namespace ModernUi.WPF.Core
{
    public class ViewModelBase : ObservableObject
    {
        public ICommand BackCommand { get; set; }

        public ViewModelBase(INavigationService navigationService)
        {
            BackCommand = navigationService.NavigateToCommand<HomeViewModel>();
        }

    }
}
