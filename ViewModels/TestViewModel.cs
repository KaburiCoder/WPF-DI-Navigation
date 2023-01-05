using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDINaviagation.Commands;
using WpfDINaviagation.Services;

namespace WpfDINaviagation.ViewModels
{
  public class TestViewModel : ViewModelBase
  {
    private readonly INavigationService _navigationService;

    private void ToLogin(object _)
    {
      _navigationService.Navigate(NaviType.LoginView);
    }

    private void ToSignup(object _)
    {
      _navigationService.Navigate(NaviType.SignupView);
    }

    public TestViewModel(INavigationService navigationService)
    {
      _navigationService = navigationService;

      ToLoginCommand = new RelayCommand<object>(ToLogin);
      ToSignupCommand = new RelayCommand<object>(ToSignup);
    }

    public ICommand ToLoginCommand { get; set; }
    public ICommand ToSignupCommand { get; set; }
  }
}
