using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Messages;
using СargoProject.Models;
using СargoProject.Services.Clsasses;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class UserSettingsViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    private UserInformationModel userInfo;

    public UserInformationModel UserInfo { get => userInfo; set => Set(ref userInfo, value); }

    public UserSettingsViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        _messenger = messenger;

        _messenger.Register<DataMessage<UserInformationModel>>(this, message =>
        {
            if (message.Data != null)
            {
                UserInfo = new(message.Data);
            }
        });
    }

    public MyRelayCommand ConfirmCommand
    {
        get => new(
        () =>
        {
            _dataService.SendData(userInfo);
            _navigationService.NavigateTo<UserMainViewModel>();
        });
    }

    public MyRelayCommand CancelCommand
    {
        get => new(
        () =>
        {
            _navigationService.NavigateTo<UserMainViewModel>();
        });
    }
}
