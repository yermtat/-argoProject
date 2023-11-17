using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;
using СargoProject.Services.Interfaces;

namespace СargoProject.Services.Clsasses;

class UserManagerService : IUserManagerService
{
    private readonly ICipherService _cipherService;
    private readonly IFileOperationService _fileOperationService;
    private readonly IJsonService _jsonService;

    public UserManagerService(ICipherService cipherService, IFileOperationService fileOperationService, IJsonService jsonService)
    {
        _cipherService = cipherService;
        _fileOperationService = fileOperationService;
        _jsonService = jsonService;
    }

    public void CreateNewUser(UserModel user)
    {
        user.Password = _cipherService.Encipher(user.Password);
        var json = _jsonService.Serialize(user);
        _fileOperationService.SaveToFile(user.Username + user.Password, json);
    }

    public UserModel LoadUser(LoginInfoModel user)
    {
        var json = _fileOperationService.LoadFromFile(user.Username + _cipherService.Encipher(user.Password));
        return _jsonService.Deserialize<UserModel> (json);
    }

    public void UpdateUser(UserModel user)
    {
        var json = _jsonService.Serialize(user);
        _fileOperationService.SaveToFile(user.Username + user.Password, json);
    }
}
