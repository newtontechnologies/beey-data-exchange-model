﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
#pragma warning disable 8625,8603
namespace Beey.DataExchangeModel
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Error
    {
        public string Message;
        public object Data;

        public Error(string message, object data = null)
        {
            Message = message;
            Data = data;
        }
    }
}
