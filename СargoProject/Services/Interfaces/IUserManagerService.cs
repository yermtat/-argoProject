using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;

namespace СargoProject.Services.Interfaces;

interface IUserManagerService
{
    public void CreateNewUser(UserModel user);
    public void UpdateUser(UserModel user);

    public UserModel LoadUser(LoginInfoModel user);
}
