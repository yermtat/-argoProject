using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Messages;
using СargoProject.Services.Interfaces;

namespace СargoProject.ViewModels;

class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IMessenger _messenger;
    private ViewModelBase currentView;

    public ViewModelBase CurrentView
    {
        get => currentView;
        set => Set(ref currentView, value);
    }

    public MainViewModel(INavigationService navigationService, IMessenger messenger)
    {
        CurrentView = App.Container.GetInstance<LoginViewModel>();

        _navigationService = navigationService;
        _messenger = messenger;

        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;
        });
    }

}
