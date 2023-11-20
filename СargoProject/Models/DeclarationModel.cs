using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Models;

class DeclarationModel :IData
{
    public string Warehouse { get; set; }
    public string SiteName { get; set; }
    public string TrackingNumber { get; set; }
    public string ProductCategory { get; set; }
    public int Quantity { get; set; }
    public string Note  { get; set; }
    public int InvoicePrice { get; set; }
    public string Currency { get; set; }
    public string InvoicePath { get; set; }
}
