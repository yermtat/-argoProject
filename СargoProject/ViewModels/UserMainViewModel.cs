using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private ObservableCollection<OrderModel> sortedOrders;

    public UserModel User { get; set; }
    public ObservableCollection<OrderModel> SortedOrders { get => sortedOrders; set => Set(ref sortedOrders, value); }
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

    public MyRelayCommand PlaceOrderCommand
    {
        get => new(
        () =>
        {
            _navigationService.NavigateTo<PlaceOrderViewModel>();
        });
    }

    public MyRelayCommand UserSettingsButton
    {
        get => new(
        () =>
        {
            _dataService.SendData(User.Info);
            _navigationService.NavigateTo<UserSettingsViewModel>();
        });
    }

    public MyRelayCommand PackagesCommand
    {
        get => new(
        () =>
        {
            SortedOrders = new(User.Orders.Where(o => o.Status == OrderModel.DeliveryStatus.Packed));
        });
    }

    public MyRelayCommand OrdersCommand
    {
        get => new(
        () =>
        {
            SortedOrders = new(User.Orders.Where(o => o.Status == OrderModel.DeliveryStatus.New));
        });
    }

    public MyRelayCommand ShippedCommand
    {
        get => new(
        () =>
        {
            SortedOrders = new(User.Orders.Where(o => o.Status == OrderModel.DeliveryStatus.Shipped));
        });
    }

    public MyRelayCommand InFilialCommand
    {
        get => new(
        () =>
        {
            SortedOrders = new(User.Orders.Where(o => o.Status == OrderModel.DeliveryStatus.InFilial));
        });
    }

    public MyRelayCommand OnCourierCommand
    {
        get => new(
        () =>
        {
            SortedOrders = new(User.Orders.Where(o => o.Status == OrderModel.DeliveryStatus.OnCourier));
        });
    }

    public MyRelayCommand HistoryCommand
    {
        get => new(
        () =>
        {
            SortedOrders = new(User.Orders.Where(o => o.Status == OrderModel.DeliveryStatus.Finished));
        });
    }

}
