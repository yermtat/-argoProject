﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Models;

class LoginInfoModel : IData
{
    public string Username { get; set; }
    public string Password { get; set; }
}
