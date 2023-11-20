using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Models;

class OrderModel : IData
{
    public string Link { get; set; }
    public string Size { get; set; }
    public string Colour { get; set; }
    public string SpecialNotes { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public int DeliveryPrice { get; set; }


    public enum DeliveryStatus { New, Packed, Shipped, InFilial, OnCourier, Finished }

    public DeliveryStatus Status { get; set; }


}
