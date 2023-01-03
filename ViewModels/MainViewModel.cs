using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDINaviagation.Services;
using WpfDINaviagation.Stores;

namespace WpfDINaviagation.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    private readonly MainNavigationStore _mainNavigationStore;
    private INotifyPropertyChanged? _currentViewModel;

    private void CurrentViewModelChanged()
    {
      CurrentViewModel = _mainNavigationStore.CurrentViewModel;
    }

    public MainViewModel(MainNavigationStore mainNavigationStore, INavigationService navigationService)
    {
      _mainNavigationStore = mainNavigationStore;
      _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
      navigationService.Navigate(NaviType.LoginView);
    }

    public INotifyPropertyChanged? CurrentViewModel
    {
      get { return _currentViewModel; }
      set
      {
        if (_currentViewModel != value)
        {
          _currentViewModel = value;
          OnPropertyChanged();
        }
      }
    }

  }
}
