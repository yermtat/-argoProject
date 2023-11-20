using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;
using СargoProject.Services.Clsasses;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class PlaceOrderViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    public OrderModel Order { get; set; } = new();

    public PlaceOrderViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        _messenger = messenger;
    }

    public MyRelayCommand ConfirmButton
    {
        get => new(
        () =>
        {
            Order.Status = OrderModel.DeliveryStatus.New;
            Order.Date = DateTime.Now;
            _dataService.SendData(Order);
            Order = new();
            _navigationService.NavigateTo<UserMainViewModel>();
        },
        () =>
        {
            return !String.IsNullOrEmpty(Order.Link) &&
            !String.IsNullOrEmpty(Order.Colour) &&
            Order.Quantity != 0 && Order.Price != 0 &&
            Order.DeliveryPrice != 0;

        });
    }

    public MyRelayCommand CancelButton { get => new(
        () =>
        {
            _navigationService.NavigateTo<UserMainViewModel>();
        });
    }
}
