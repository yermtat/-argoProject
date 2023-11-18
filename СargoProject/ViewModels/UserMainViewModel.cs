using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Messages;
using СargoProject.Models;
using СargoProject.Services.Clsasses;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class UserMainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private readonly IUserManagerService _userManagerService;

    public UserModel User { get; set; }
    public UserMainViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger, IUserManagerService userManagerService)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        _messenger = messenger;
        _userManagerService = userManagerService;

        _messenger.Register<DataMessage<UserModel>>(this, message =>
        {
            if (message.Data != null)
            {
                User = message.Data;
            }
        });

        _messenger.Register<DataMessage<OrderModel>>(this, message =>
        {
            if (message.Data != null)
            {
                User.Orders.Add(message.Data);
                _userManagerService.UpdateUser(User);
            }
        });

        _messenger.Register<DataMessage<UserInformationModel>>(this, message =>
        {
            if (message.Data != null)
            {
                User.Info = message.Data;
                _userManagerService.UpdateUser(User);
            }
        });
    }

    public MyRelayCommand PlaceOrderCommand { get => new(
        () =>
        {
            _navigationService.NavigateTo<PlaceOrderViewModel>();
        });
    }

    public MyRelayCommand UserSettingsButton {
        get => new(
        () =>
        {
            _dataService.SendData(User.Info);
            _navigationService.NavigateTo<UserSettingsViewModel>();
        });
    }
}
