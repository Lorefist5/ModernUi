using ModernUi.Data.Model;
using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;

namespace ModernUi.WPF.ViewModel.Base
{
    public class UserViewModelBase : ViewModelBase
    {
        protected User _user = new User();

        public User User
        {
            get { return _user; }
            set
            {
                _user = value ?? new User();
                OnPropertyChanged(nameof(User));
            }
        }

        public string UserName
        {
            get { return User.Name; }
            set
            {
                User.Name = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string UserEmail
        {
            get { return User.Email; }
            set
            {
                User.Email = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        public string UserPassword
        {
            get { return User.Password; }
            set
            {
                User.Password = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }
        public UserViewModelBase(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
