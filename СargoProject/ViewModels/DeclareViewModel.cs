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

class DeclareViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private DeclarationModel declaration = new();

    public DeclarationModel Declaration { get => declaration; set => Set(ref declaration, value); }
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
            return !String.IsNullOrEmpty(Declaration.Warehouse) &&
            !String.IsNullOrEmpty(Declaration.SiteName) &&
            !String.IsNullOrEmpty(Declaration.TrackingNumber) &&
            !String.IsNullOrEmpty(Declaration.ProductCategory) &&
            Declaration.Quantity != 0 && Declaration.InvoicePrice != 0 &&
            !String.IsNullOrEmpty(Declaration.Currency) &&
            !String.IsNullOrEmpty(Declaration.InvoicePath);

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

    public MyRelayCommand ChooseFileButton
    {
        get => new(
        () =>
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "pdf documents (.pdf)|*.pdf";

            if (dlg.ShowDialog() == true)
            {
                Declaration.InvoicePath = dlg.FileName;
            }
        });
    }

}
