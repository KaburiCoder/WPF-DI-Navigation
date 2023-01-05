using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDINaviagation.Commands;
using WpfDINaviagation.Services;
using WpfDINaviagation.Stores;

namespace WpfDINaviagation.ViewModels
{
  public class LoginViewModel : ViewModelBase
  {
    private readonly INavigationService _navigationService;
    private readonly SignupStore _signupStore;
    private string _id = "";
    private string _password = "";

    private void ToSignup(object _)
    {
      _signupStore.CurrentAccount = new Models.Account { Id = Id, Password = Password };
      _navigationService.Navigate(NaviType.SignupView);
    }

    private void ToTest(object _)
    {
      _navigationService.Navigate(NaviType.TestView);
    }

    public LoginViewModel(INavigationService navigationService, SignupStore signupStore)
    {
      _navigationService = navigationService;
      _signupStore = signupStore;

      ToSignupCommand = new RelayCommand<object>(ToSignup);
      ToTestCommand = new RelayCommand<object>(ToTest);
    }
     
    public string Id
    {
      get { return _id; }
      set
      {
        if (_id != value)
        {
          _id = value;
          OnPropertyChanged();
        }
      }
    }
       
    public string Password
    {
      get { return _password; }
      set
      {
        if (_password != value)
        {
          _password = value;
          OnPropertyChanged();
        }
      }
    }

    public ICommand ToSignupCommand { get; set; }
    public ICommand ToTestCommand { get; set; }
  }
}
