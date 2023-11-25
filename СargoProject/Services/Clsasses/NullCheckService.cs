using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using СargoProject.Models;
using СargoProject.Services.Interfaces;

namespace СargoProject.Services.Clsasses;

internal class NullCheckService : INullCheckService
{
    public bool CheckDeclaration(DeclarationModel declaration)
    {
        return !String.IsNullOrEmpty(declaration.Warehouse) &&
        !String.IsNullOrEmpty(declaration.SiteName) &&
        !String.IsNullOrEmpty(declaration.TrackingNumber) &&
        !String.IsNullOrEmpty(declaration.ProductCategory) &&
        declaration.Quantity != 0 && declaration.InvoicePrice != 0 &&
        !String.IsNullOrEmpty(declaration.Currency) &&
        !String.IsNullOrEmpty(declaration.InvoicePath);
    }

    public bool CheckOrder(OrderModel order)
    {
        return !String.IsNullOrEmpty(order.Link) &&
        !String.IsNullOrEmpty(order.Colour) &&
        order.Quantity != 0 && order.Price != 0 &&
        order.DeliveryPrice != 0;
    }

    public bool CheckUser(UserModel user)
    {
        return !String.IsNullOrEmpty(user.Username) &&
            !String.IsNullOrEmpty(user.Password) &&
            user.Info.PhoneNumber != 0 &&
            !String.IsNullOrEmpty(user.Info.PassportSerial) &&
            !String.IsNullOrEmpty(user.Info.Fin) && user.Info.Fin.Length == 6 &&
            !String.IsNullOrEmpty(user.Info.Address);
    }
}
