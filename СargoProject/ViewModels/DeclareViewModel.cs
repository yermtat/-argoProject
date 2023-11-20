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

 class DeclareViewModel: ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    public DeclarationModel Declaration { get; set; } = new();

    public DeclareViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        _messenger = messenger;
    }

    public MyRelayCommand ConfirmCommand
    {
        get => new(
        () =>
        {
            _dataService.SendData(Declaration);
            Declaration = new();
            _navigationService.NavigateTo<UserMainViewModel>();
        },
        () =>
        {
            return true;

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
