﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf.Converters;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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


    public ObservableCollection<OrderModel> SortedOrders { get => sortedOrders; set => Set(ref sortedOrders, value); }

    public OrderModel SelectedOrder { get; set; }
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

        _messenger.Register<DataMessage<DeclarationModel>>(this, message =>
        {
            if (message.Data != null)
            {
                User.Declarations.Add(message.Data);
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

    public MyRelayCommand DeclareCommand
    {
        get => new(
        () =>
        {
            _navigationService.NavigateTo<DeclareViewModel>();
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

    public MyRelayCommand QuitCommand
    {
        get => new(
        () =>
        {
            _navigationService.NavigateTo<LoginViewModel>();
            User = new();
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

    public MyRelayCommand DetailsCommand
    {
        get => new(
        () =>
        {
            MessageBox.Show($"Size: {SelectedOrder.Size}\nColour: {SelectedOrder.Colour}\n" +
                $"Quantity: {SelectedOrder.Quantity}\nPrice: {SelectedOrder.Price}\n" +
                $"Delivery price: {SelectedOrder.DeliveryPrice}\nSpecial notes: {SelectedOrder.SpecialNotes}", "Order details",
                MessageBoxButton.OK, MessageBoxImage.Information);
        });
    }

    public MyRelayCommand LastMonthCommand
    {
        get => new(
        () =>
        {
            MessageBox.Show($"Money spent: {User.Orders.Where(d => d.Date.Month == DateTime.Now.Month).Sum(d => d.Price + d.DeliveryPrice)}",
               "Month spending", MessageBoxButton.OK, MessageBoxImage.Information);
        });
    }

    public MyRelayCommand CashbackCommand
    {
        get => new(
        () =>
        {
            MessageBox.Show($"This month cashback: {User.Orders.Where(d => d.Date.Month == DateTime.Now.Month).Sum(d => (d.Price + d.DeliveryPrice)*10/100)}",
               "Cashback 10%", MessageBoxButton.OK, MessageBoxImage.Information);
        });
    }

    public MyRelayCommand BalanceCommand
    {
        get => new(
        () =>
        {
            MessageBox.Show($"Feature in development", "Balance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        });
    }

    public MyRelayCommand DiscountCommand
    {
        get => new(
        () =>
        {
            MessageBox.Show($"No available discount at the moment", "Discount", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        });
    }


}
