using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Models;

namespace СargoProject.Messages;

class DataMessage<T>
{
    //public IData Data { get; set; }

    public T Data { get; set; }

}
