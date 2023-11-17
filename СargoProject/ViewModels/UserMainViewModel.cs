using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Messages;
using СargoProject.Models;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class UserMainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    public UserModel User { get; set; } 
    public UserMainViewModel(INavigationService navigationService, IDataService dataService, IMessenger messenger)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        _messenger = messenger;

        _messenger.Register<DataMessage>(this, message =>
        {
            if (message.Data != null)
            {
                User = message.Data as UserModel;
            }
        });
    }
}
