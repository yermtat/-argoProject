using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using СargoProject.Models;
using СargoProject.Services.Clsasses;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class LoginViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IUserManagerService _userManagerService;


    private LoginInfoModel user = new();

    public LoginInfoModel User { get => user; set => Set(ref user, value); }

    public LoginViewModel(INavigationService navigationService, IUserManagerService userManagerService, IDataService dataService = null)
    {
        _navigationService = navigationService;
        _userManagerService = userManagerService;
        _dataService = dataService;
    }

    public MyRelayCommand LoginCommand
    {
        get => new(
        () =>
        {
            try
            {
                var data = _userManagerService.LoadUser(User);
                _dataService.SendData(data);
                _navigationService.NavigateTo<UserMainViewModel>();

            }
            catch (Exception)
            {
                MessageBox.Show("Wrong username or password");
            }
        },
        () =>
        {
            return !String.IsNullOrEmpty(User.Username) && !String.IsNullOrEmpty(User.Password);
        }
        );

    }

    public MyRelayCommand SignupCommand
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<SignUpViewModel>();
            });
    }
}
