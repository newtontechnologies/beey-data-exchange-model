﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeyApi.POCO.Emails
{
    public partial class PlainEmail : Email
    {
        public string Body { get; set; }
    }
}
