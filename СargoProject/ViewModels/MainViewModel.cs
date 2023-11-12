using GalaSoft.MvvmLight;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.ViewModels;

class MainViewModel : ViewModelBase
{
    private ViewModelBase currentView;

    public ViewModelBase CurrentView
    {
        get => currentView;
        set => Set(ref currentView, value);
    }

    public MainViewModel()
    {
        CurrentView = App.Container.GetInstance<PlaceOrderViewModel>();
    }
}
