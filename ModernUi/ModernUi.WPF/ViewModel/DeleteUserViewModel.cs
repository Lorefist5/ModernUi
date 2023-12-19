using ModernUi.Data.Model;
using ModernUi.Data.Repositories.Interfaces;
using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;
using ModernUi.WPF.ViewModel.Base;
using System.Windows.Input;

namespace ModernUi.WPF.ViewModel
{
    public class DeleteUserViewModel : UserViewModelBase
    {

        public ICommand DeleteUser { get; private set; }
        public DeleteUserViewModel(INavigationService navigationService, IAlertService alertService, IUnitOfWork unitOfWork, User user) : base(navigationService)
        {
            User = user;
            BackCommand = navigationService.NavigateToCommand<UsersViewModel>();

            DeleteUser = new RelayCommand(async o =>
            {
                await unitOfWork.UserRepository.Delete(_user);
                unitOfWork.SaveChanges();
                navigationService.NavigateTo<UsersViewModel>();
                alertService.PopUp("Deleted", $"User was deleted successfully!");
            }, o => true);
        }
    }
}
