using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.POCO.Emails
{
    public abstract partial class Email
    {
        public Email()
        {
            From = "noreply@beey.io";
        }


        public string[] To { get; set; }
        public string[] CC { get; set; }
        public string[] BCC { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
    }
}
