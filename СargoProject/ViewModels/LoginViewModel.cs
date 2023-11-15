using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;
using СargoProject.Services.Clsasses;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class LoginViewModel : ViewModelBase
{
    private ICipherService _cipherService;
    private LoginInfoModel user = new();

    public LoginInfoModel User { get => user; set => Set(ref user, value); }

    public LoginViewModel(ICipherService cipherService)
    {
        _cipherService = cipherService;
    }

    public MyRelayCommand LoginCommand
    {
        get => new(
        () =>
        {
            var str = _cipherService.Encipher(User.Password); 
        },
        () =>
        {
            return !String.IsNullOrEmpty(User.Username) && !String.IsNullOrEmpty(User.Password);
        }
        );

    }
}
