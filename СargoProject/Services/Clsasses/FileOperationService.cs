using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using СargoProject.Services.Interfaces;

namespace СargoProject.Services.Clsasses;

class FileOperationService : IFileOperationService
{
    public string LoadFromFile(string filePath)
    {
        using FileStream fs = new(filePath + ".json", FileMode.Open);
        using StreamReader sr = new(fs);

        return sr.ReadToEnd();

    }

    public void SaveToFile(string filePath, string json)
    {
        using FileStream fs = new(filePath + ".json", FileMode.Create);
        using StreamWriter sw = new(fs);

        sw.WriteLine(json);
    }
}
