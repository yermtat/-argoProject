using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;

namespace СargoProject.Services.Interfaces;

interface INullCheckService
{
    public bool CheckUser(UserModel user);

    public bool CheckOrder(OrderModel order);

    public bool CheckDeclaration(DeclarationModel declaration);
}
