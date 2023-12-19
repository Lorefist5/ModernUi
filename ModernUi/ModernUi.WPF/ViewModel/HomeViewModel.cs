using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;
using System.Windows.Input;

namespace ModernUi.WPF.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateToUsers { get; private set; }
        public ICommand Welcome { get; private set; }   
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToUsers = navigationService.NavigateToCommand<UsersViewModel>();

        }
    }
}
