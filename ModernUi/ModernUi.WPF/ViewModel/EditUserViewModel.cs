using ModernUi.Data.Model;
using ModernUi.Data.Repositories.Interfaces;
using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;
using ModernUi.WPF.ViewModel.Base;
using System.Windows.Input;

namespace ModernUi.WPF.ViewModel
{
    public class EditUserViewModel : UserViewModelBase
    {
        public ICommand EditUser { get; private set; }
        public EditUserViewModel(INavigationService navigationService, IAlertService alertService, IUnitOfWork unitOfWork, User user) : base(navigationService)
        {
            BackCommand = navigationService.NavigateToCommand<UsersViewModel>();
            User = user;
            EditUser = new RelayCommand(o =>
            {
                unitOfWork.UserRepository.Update(_user);
                unitOfWork.SaveChanges();
                navigationService.NavigateTo<UsersViewModel>();
                alertService.PopUp("Edited", $"User was edited.");
            },
            o => !string.IsNullOrWhiteSpace(User.Email) &&
                !string.IsNullOrWhiteSpace(User.Name) &&
                !string.IsNullOrWhiteSpace(User.Password) &&
                !string.IsNullOrWhiteSpace(User.Email) &&
                User.Name.Length >= 3 &&
                User.Name.Length <= 30 &&
                User.Email.Length >= 3 &&
                User.Email.Length <= 50 &&
                User.Password.Length >= 3 &&
                User.Password.Length <= 20

            , this);
        }
    }
}
