using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Utility
{
    public static string Reverse(string str)
    {
        char[] array = str.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

    public static int Power(int num, int pow)
    {
        if (pow < 0) return 0;
        int output = 1;
        while (pow > 0)
        {
            output *= num;
            pow--;
        }
        return output;
    }
}

