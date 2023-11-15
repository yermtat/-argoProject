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
    private ICipherService _cipherService;
    public UserModel User { get; set; } = new();
    public string PasswordConfirmation { get; set; } 
    public SignUpViewModel(ICipherService cipherService)
    {
        _cipherService = cipherService;
    }

    public MyRelayCommand ConfirmButton { get => new(
        () =>
        {

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
