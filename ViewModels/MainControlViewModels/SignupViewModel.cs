using System.Windows.Input;
using WpfDINaviagation.Commands;
using WpfDINaviagation.Services;

namespace WpfDINaviagation.ViewModels
{
  public class SignupViewModel : ViewModelBase
  {
    private readonly INavigationService _navigationService;

    private void ToLogin(object _)
    {
      _navigationService.Navigate(NaviType.LoginView);
    }

    private void ToTest(object _)
    {
      _navigationService.Navigate(NaviType.TestView);
    }

    public SignupViewModel(INavigationService navigationService)
    {
      _navigationService = navigationService;

      ToLoginCommand = new RelayCommand<object>(ToLogin);
      ToTestCommand = new RelayCommand<object>(ToTest);
    }

    public ICommand ToLoginCommand { get; set; }
    public ICommand ToTestCommand { get; set; }
  }
}
