﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СargoProject.Services.Interfaces;

interface ICipherService
{
    public string Encipher(string str);

    public string Decipher(string str);
}
