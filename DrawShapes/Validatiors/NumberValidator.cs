using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validatiors
{
    public class NumberValidator
    {
        public static bool ValidateNumber(string number)
        {
            float paresedNUmber = 0;
            bool valid = float.TryParse(number, out paresedNUmber);
            if (paresedNUmber < 0) valid = false;
            return valid;
        }
    }
}
