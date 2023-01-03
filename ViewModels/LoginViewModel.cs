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
  public class LoginViewModel : ViewModelBase
  {
    private readonly INavigationService _navigationService;

    private void ToSignup(object _)
    {
      _navigationService.Navigate(NaviType.SignupView);
    }

    private void ToTest(object _)
    {
      _navigationService.Navigate(NaviType.TestView);
    }

    public LoginViewModel(INavigationService navigationService)
    {
      _navigationService = navigationService;

      ToSignupCommand = new RelayCommand<object>(ToSignup);
      ToTestCommand = new RelayCommand<object>(ToTest);
    }

    public ICommand ToSignupCommand { get; set; }
    public ICommand ToTestCommand { get; set; }
  }
}
