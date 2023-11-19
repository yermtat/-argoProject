using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Models;

class UserInformationModel : IData
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PassportSerial { get; set; }
    public string Fin { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }

    public UserInformationModel()
    {

    }
    public UserInformationModel(UserInformationModel info)
    {
        Email = info.Email;
        Name = info.Name;
        Surname = info.Surname;
        PassportSerial = info.PassportSerial;
        Fin = info.Fin;
        PostalCode = info.PostalCode;
        PhoneNumber = info.PhoneNumber;
        City = info.City;
        District = info.District;
        Address = info.Address;

    }
}
