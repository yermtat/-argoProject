using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Models;

class UserModel : IData
{
    public string Username { get; set; }
    public string Password { get; set; }
    public UserInformationModel Info { get; set; } = new();
    public ObservableCollection<OrderModel> Orders { get; set; } = new();
}

