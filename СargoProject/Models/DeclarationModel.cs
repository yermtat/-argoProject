using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Models;

internal class DeclarationModel : IData
{
    public string Warehouse { get; set; }
    public string SiteName { get; set; }
}
