using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using СargoProject.ViewModels;
using СargoProject.Views;

namespace СargoProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }

        void Register()
        {
            Container = new();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<DeclareViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<PlaceOrderViewModel>();
            Container.RegisterSingleton<SignUpViewModel>();
            Container.RegisterSingleton<UserMainViewModel>();
            Container.RegisterSingleton<UserSettingsViewModel>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView();
            window.DataContext = Container.GetInstance<MainViewModel>();

            window.ShowDialog();
        }
    }
}
