﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;

namespace СargoProject.Services.Interfaces;

interface IJsonService
{
    public string Serialize(UserModel user);

    public UserModel Deserialize<UserModel>(string json);
}
