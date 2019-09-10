using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Emails
{
    public partial class PlainEmail : Email
    {
        public string Body { get; set; }
    }
}
