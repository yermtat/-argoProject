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
    private readonly INullCheckService _nullCheckService;

    public OrderModel Order { get; set; } = new();

    public PlaceOrderViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger, INullCheckService nullCheckService)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        _messenger = messenger;
        _nullCheckService = nullCheckService;
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
            return _nullCheckService.CheckOrder(Order);

        });
    }

    public MyRelayCommand CancelButton { get => new(
        () =>
        {
            _navigationService.NavigateTo<UserMainViewModel>();
        });
    }
}
