using Beey.DataExchangeModel.Auth;
using Beey.DataExchangeModel.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Workspaces
{
    public class Workspace : EntityBase
    {
        public int? OwnerId { get; set; }
        public ICollection<User> Users { get; set; }
        [JsonIgnoreWebDeserialize]
        public decimal TranscribedMinutes { get; set; }
        public int CreditMinutes { get; set; }
        [JsonIgnore]
        public decimal ReservedCreditMinutes { get; set; }
    }
}
