using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СargoProject.Services.Interfaces;

namespace СargoProject.Services.Clsasses;

class CipherService : ICipherService
{
    private int _key = 4;
    public string Decipher(string str)
    {
        char[] strChar = str.ToCharArray();

        for (int i = 0; i < strChar.Length; i++)
        {
            if (strChar[i] >= 'A' && strChar[i] <= 'Z' || strChar[i] >= 'a' && strChar[i] <= 'z')
            {
                if (strChar[i] <= 'Z' && strChar[i] > 'Z' - _key)
                {
                    strChar[i] = (char)('A' - 1 + (_key - ('Z' - strChar[i])));
                }
                else if (strChar[i] > 'z' - _key)
                {
                    strChar[i] = (char)('a' - 1 + (_key - ('z' - strChar[i])));
                }
                else
                {
                    strChar[i] += (char)_key;
                }
            }
        }

        return new string(strChar);
    }

    public string Encipher(string str)
    {
        char[] strChar = str.ToCharArray();

        for (int i = 0; i < strChar.Length; i++)
        {
            if (strChar[i] >= 'A' && strChar[i] <= 'Z' || strChar[i] >= 'a' && strChar[i] <= 'z')
            {
                if (strChar[i] < 'A' + _key)
                {
                    strChar[i] = (char)('Z' + 1 - (_key - (strChar[i] - 'A')));
                }
                else if (strChar[i] >= 'a' && strChar[i] < 'a' + _key)
                {
                    strChar[i] = (char)('z' + 1 - (_key - (strChar[i] - 'a')));
                }
                else
                {
                    strChar[i] -= (char)_key;
                }
            }
        }

        return new string(strChar);
    }
}
