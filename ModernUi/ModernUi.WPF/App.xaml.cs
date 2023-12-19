using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModernUi.Data;
using ModernUi.Data.Model;
using ModernUi.Data.Repositories.Interfaces;
using ModernUi.Data.Repositories.ORM;
using ModernUi.WPF.Core;
using ModernUi.WPF.Services;
using ModernUi.WPF.Services.Interfaces;
using ModernUi.WPF.ViewModel;
using System.Windows;

namespace ModernUi.WPF
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddTransient<UsersViewModel>();      // We use Transient so that it fetches the users again
            services.AddTransient<CreateUserViewModel>(); // We use Transient so that it clears the input fields
            services.AddSingleton<DeleteUserViewModel>();
            services.AddSingleton<EditUserViewModel>();

            //Services

            //Native Alerts
            services.AddSingleton<IAlertService, AlertService>();
            //File system
            services.AddSingleton<IFileSystem, DesktopFileSystem>();
            //EF core
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data source=ModernUiDatabase.db"));
            services.AddSingleton<IUserRepository, UserRepositoryORM>();
            services.AddSingleton<IUnitOfWork, UnitOfWorkORM>();

            //Navigation
            services.AddSingleton<INavigationService, NavigationService>(provider =>
            {
                var navigationService = new NavigationService(provider.GetRequiredService<Func<Type, ViewModelBase>>());
                
                return navigationService;
            });

            services.AddSingleton<Func<Type, ViewModelBase>>(provider =>
                request => (ViewModelBase)provider.GetRequiredService(request));


            //Models
            services.AddScoped<User>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            _serviceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}


