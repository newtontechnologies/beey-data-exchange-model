using Beey.DataExchangeModel.Serialization;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects
{
    public class LastProjectError : EntityBase
    {
        public int ProjectId { get; set; }
        [JsonIgnoreWebDeserialize]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public ProjectErrorCause Cause { get; set; }
        [JsonIgnoreWebDeserialize]
        public string Detail { get; set; }
    }
}
