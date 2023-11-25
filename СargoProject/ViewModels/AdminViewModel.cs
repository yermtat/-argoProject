using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using СargoProject.Models;
using СargoProject.Services.Clsasses;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class AdminViewModel : ViewModelBase
{
    private readonly IFileOperationService _fileOperationService;
    private readonly IJsonService _jsonService;
    private readonly IUserManagerService _userManagerService;
    private readonly INavigationService _navigationService;

    public AdminViewModel(IFileOperationService fileOperationService, IJsonService jsonService, IUserManagerService userManagerService, INavigationService navigationService)
    {
        _fileOperationService = fileOperationService;
        _jsonService = jsonService;
        _userManagerService = userManagerService;
        _navigationService = navigationService;
    }

    public UserModel User { get; set; }
    public OrderModel SelectedOrder { get; set; }


    public MyRelayCommand ChooseFileButton
    {
        get => new(
        () =>
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "users (.json)|*.json";

            if (dlg.ShowDialog() == true)
            {
                var json = _fileOperationService.LoadAdmin(dlg.FileName);
                User = _jsonService.Deserialize<UserModel>(json);
            }
        });
    }

    public MyRelayCommand PackedCommand
    {
        get => new(
        () =>
        {
            SelectedOrder.Status = OrderModel.DeliveryStatus.Packed;
            _userManagerService.UpdateUser(User);
        });
    }

    public MyRelayCommand ShippedCommand
    {
        get => new(
        () =>
        {
            SelectedOrder.Status = OrderModel.DeliveryStatus.Shipped;
            _userManagerService.UpdateUser(User);
        });
    }

    public MyRelayCommand InFilialCommand
    {
        get => new(
        () =>
        {
            SelectedOrder.Status = OrderModel.DeliveryStatus.InFilial;
            _userManagerService.UpdateUser(User);
        });
    }

    public MyRelayCommand OnCourierCommand
    {
        get => new(
        () =>
        {
            SelectedOrder.Status = OrderModel.DeliveryStatus.OnCourier;
            _userManagerService.UpdateUser(User);
        });
    }

    public MyRelayCommand FinishedCommand
    {
        get => new(
        () =>
        {
            SelectedOrder.Status = OrderModel.DeliveryStatus.Finished;
            _userManagerService.UpdateUser(User);
        });
    }

    public MyRelayCommand LoginButton
    {
        get => new(
        () =>
        {
            _navigationService.NavigateTo<LoginViewModel>();
        });
    }
}
