using ModernUi.Data.Model;
using ModernUi.Data.Repositories.Interfaces;
using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ModernUi.WPF.ViewModel
{
    public class UsersViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        private readonly IUnitOfWork unitOfWork;

        public ICommand NavigateToCreateUsers { get; private set; }
        public ICommand NavigateToDeleteUser { get; private set; }
        public ICommand NavigateToEdit { get; private set; }
        public UsersViewModel(INavigationService navigationService, IUnitOfWork unitOfWork, IAlertService alertService) : base(navigationService)
        {
            this.unitOfWork = unitOfWork;

            NavigateToCreateUsers = navigationService.NavigateToCommand<CreateUserViewModel>();

            NavigateToDeleteUser = new RelayCommand(o =>
            {
                var selectedUser = o as User;
                DeleteUserViewModel dl = new DeleteUserViewModel(navigationService, alertService, unitOfWork, selectedUser);
                navigationService.Navigate(dl);

            }, o => true);

            NavigateToEdit = new RelayCommand(o =>
            {
                var selectedUser = o as User;
                EditUserViewModel ed = new EditUserViewModel(navigationService, alertService, unitOfWork, selectedUser);
                navigationService.Navigate(ed);
            }, o => true);

            
            Init();
        }

        private async void Init()
        {

            var users = await unitOfWork.UserRepository.GetAll();
            Users.Clear();

            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}
