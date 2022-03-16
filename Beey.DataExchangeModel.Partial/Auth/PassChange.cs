using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Auth
{
    public partial class PassChange
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
