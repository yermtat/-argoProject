using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using СargoProject.Models;
using СargoProject.Services.Interfaces;

namespace СargoProject.Services.Clsasses;

class JsonService : IJsonService
{
    public UserModel Deserialize<UserModel>(string json)
    {
        return JsonSerializer.Deserialize<UserModel>(json) ?? throw new NullReferenceException("Data is null");
    }

    public string Serialize(UserModel user)
    {
        return JsonSerializer.Serialize(user);
    }
}
