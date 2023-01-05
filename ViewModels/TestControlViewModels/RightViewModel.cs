using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDINaviagation.Commands;
using WpfDINaviagation.Models;
using WpfDINaviagation.Stores;

namespace WpfDINaviagation.ViewModels
{
  public class RightViewModel : ViewModelBase
  {
    private string _id = "";
    private string _password = "";
    private string _name = "";
    private string _email = "";
    private readonly RightStore _rightStore;
    private readonly LeftStore _leftStore;

    private Account CurrentAccount => _rightStore.CurrentAccount!;

    private void SendAccountToLeft(object _)
    {
      _leftStore.CurrentAccount = new Account
      {
        Id = Id,
        Password = Password,
        Name = Name,
        Email = Email,
      };
    }

    private void CurrentAccountChanged(Account account)
    {
      Id = account.Id;
      Password = account.Password;
      Name = account.Name;
      Email = account.Email;
    }

    public RightViewModel(RightStore rightStore, LeftStore leftStore)
    {
      _rightStore = rightStore;
      _leftStore = leftStore;
      _rightStore.CurrentAccountChanged += CurrentAccountChanged;
      
      SendAccountToLeftCommand = new RelayCommand<object>(SendAccountToLeft);
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

    public string Name
    {
      get { return _name; }
      set
      {
        if (_name != value)
        {
          _name = value;
          OnPropertyChanged();
        }
      }
    }

    public string Email
    {
      get { return _email; }
      set
      {
        if (_email != value)
        {
          _email = value;
          OnPropertyChanged();
        }
      }
    }

    public ICommand SendAccountToLeftCommand { get; set; }
  }
}
