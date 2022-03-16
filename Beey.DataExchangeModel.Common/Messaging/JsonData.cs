using Beey.DataExchangeModel.Serialization.JsonConverters;
using System;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging
{
    public class JsonData
    {
        public string Raw { get; }

        public JsonData(string raw)
        {
            Raw = raw;
        }
    }
}
