using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Users
{
    public class Country
    {
        public string NativeName { get; set; }
        public string Code { get; set; }

        public Country(string nativeName, string code)
        {
            NativeName = nativeName;
            Code = code;
        }
    }
}
