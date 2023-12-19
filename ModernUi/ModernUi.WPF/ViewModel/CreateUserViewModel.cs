using ModernUi.Data.Repositories.Interfaces;
using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;
using ModernUi.WPF.ViewModel.Base;
using System.Windows.Input;

namespace ModernUi.WPF.ViewModel
{
    public class CreateUserViewModel : UserViewModelBase
    {


        public ICommand CreateUser { get; private set; }
        public CreateUserViewModel(INavigationService navigationService, IUnitOfWork unitOfWork, IAlertService alertService) : base(navigationService)
        {
            BackCommand = navigationService.NavigateToCommand<UsersViewModel>();
            CreateUser = new RelayCommand(async o =>
            {
                await unitOfWork.UserRepository.Add(this._user);
                unitOfWork.SaveChanges();
                navigationService.NavigateTo<UsersViewModel>();
                alertService.PopUp("Created", $"User was created successfully!");
            },
           o => !string.IsNullOrWhiteSpace(User.Email) &&
                !string.IsNullOrWhiteSpace(User.Name) &&
                !string.IsNullOrWhiteSpace(User.Password) &&
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
