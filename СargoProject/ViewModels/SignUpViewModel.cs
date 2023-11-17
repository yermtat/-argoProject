using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;
using СargoProject.Services.Clsasses;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class SignUpViewModel : ViewModelBase
{
    private readonly IUserManagerService _userManagerService;
    private readonly INavigationService _navigationService;

    public SignUpViewModel(IUserManagerService userManagerService, INavigationService navigationService)
    {
        _userManagerService = userManagerService;
        _navigationService = navigationService;
    }

    public UserModel User { get; set; } = new();
    public string PasswordConfirmation { get; set; } 

    public MyRelayCommand ConfirmButton { get => new(
        () =>
        {
            _userManagerService.CreateNewUser(User);
            PasswordConfirmation = null;
            _navigationService.NavigateTo<LoginViewModel>();

        },
        () =>
        {
            return !String.IsNullOrEmpty(User.Username) &&
            !String.IsNullOrEmpty(User.Password) &&
            !String.IsNullOrEmpty(PasswordConfirmation) &&
            !String.IsNullOrEmpty(User.Info.PhoneNumber) &&
            !String.IsNullOrEmpty(User.Info.PassportSerial) &&
            !String.IsNullOrEmpty(User.Info.Fin) &&
            !String.IsNullOrEmpty(User.Info.Address) &&
            User.Password == PasswordConfirmation;
        });
    }
}
