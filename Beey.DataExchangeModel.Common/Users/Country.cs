using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users
{
    public class Country
    {
        public string Name { get; set; }
        public string NativeName { get; set; }

        // For backward compatibility.
        public string Code => TwoLetterIsoCode;
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public string NumericCode { get; set; }

        public Country(string name, string nativeName, string twoLetterIsoCode, string threeLetterIsoCode, string numericCode)
        {
            Name = name;
            NativeName = nativeName;
            TwoLetterIsoCode = twoLetterIsoCode;
            ThreeLetterIsoCode = threeLetterIsoCode;
            NumericCode = numericCode;
        }
    }
}
