using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Beey.DataExchangeModel.Emails;

public abstract class Email
{
    public Email()
    {
        From = "noreply@beey.io";
    }


    public string[] To { get; set; }
    public string[] CC { get; set; } = new string[0];
    public string[] BCC { get; set; } = new string[0];
    public string From { get; set; }
    public string Subject { get; set; }
}
