using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;
using System.Windows.Input;

namespace ModernUi.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService = default!;
        public INavigationService Navigation
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToUsers { get; private set; }
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            Navigation = navigationService;

            Navigation.NavigateTo<HomeViewModel>();


            NavigateToUsers = navigationService.NavigateToCommand<UsersViewModel>();




        }
    }
}
