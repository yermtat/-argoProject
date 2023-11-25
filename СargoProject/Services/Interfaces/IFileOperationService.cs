using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Services.Interfaces;

interface IFileOperationService
{
    public void SaveToFile(string filePath, string json);

    public string LoadFromFile(string filePath);

    public string LoadAdmin(string filePath);
}
