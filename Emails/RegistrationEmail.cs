using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8618
namespace Beey.DataExchangeModel.Emails
{
    public partial class RegistrationEmail : Email
    {
        public string WebURL { get; set; }
        public string URLName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public RegistrationEmail()
        {
            Subject = "Registrace účtu Beey";
        }
    }
}
