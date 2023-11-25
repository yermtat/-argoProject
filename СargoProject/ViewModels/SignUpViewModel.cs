using GalaSoft.MvvmLight;
using Prism.Commands;
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

class SignUpViewModel : ViewModelBase
{
    private readonly IUserManagerService _userManagerService;
    private readonly INavigationService _navigationService;
    private readonly INullCheckService _nullCheckService;
    private UserModel user = new();

    public SignUpViewModel(IUserManagerService userManagerService, INavigationService navigationService, INullCheckService nullCheckService)
    {
        _userManagerService = userManagerService;
        _navigationService = navigationService;
        _nullCheckService = nullCheckService;
    }

    public UserModel User { get => user; set => Set(ref user, value); }
    public string PasswordConfirmation { get; set; }

    public MyRelayCommand ConfirmCommand
    {
        get => new(
        () =>
        {
            _userManagerService.CreateNewUser(User);
            PasswordConfirmation = null;
            User = new();
            _navigationService.NavigateTo<LoginViewModel>();

        },
        () =>
        {
            return _nullCheckService.CheckUser(User) &&
            !String.IsNullOrEmpty(PasswordConfirmation) &&
            User.Password == PasswordConfirmation;
        });
    }

    public MyRelayCommand CancelCommand
    {
        get => new(
    () =>
    {
        User = new();
        PasswordConfirmation = null;
        _navigationService.NavigateTo<LoginViewModel>();
    });
    }


}
