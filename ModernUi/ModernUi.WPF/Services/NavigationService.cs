using ModernUi.WPF.Core;
using ModernUi.WPF.Services.Interfaces;
using System.Windows.Input;

namespace ModernUi.WPF.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModelBase _currentViewModel;
        private readonly Func<Type, ViewModelBase> _viewModelFactory;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        /// <summary>
        /// Navigates to a new ViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the ViewModel to navigate to</typeparam>
        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentViewModel = viewModel;

        }
        /// <summary>
        /// Navigates to a new ViewModel.
        /// </summary>
        /// <param name="viewModel">The ViewModel to navigate to.</param>
        /// <remarks>
        /// Method for navigating to a ViewModel with custom Dependencies and parameters
        /// </remarks>
        public void Navigate(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;

        }

        public ICommand NavigateCommand(ViewModelBase viewModel)
        {
            var navigateCommand = new RelayCommand(o =>
            {
                Navigate(viewModel);
            }, o => true);

            return navigateCommand;
        }
        public ICommand NavigateToCommand<TViewModel>() where TViewModel : ViewModelBase
        {
            var navigateCommand = new RelayCommand(o =>
            {
                NavigateTo<TViewModel>();
            }, o => true);

            return navigateCommand;
        }

    }
}
