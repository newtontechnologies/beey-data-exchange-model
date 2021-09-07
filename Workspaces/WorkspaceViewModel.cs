using Beey.DataExchangeModel.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Workspaces
{
    public class WorkspaceViewModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public (int Id, string Email)[] Members { get; set; }
        public int CreditMinutes { get; set; }
        public decimal TranscribedMinutes { get; set; }
        public bool DidPay { get; set; }
        public JArray CustomProjectTags { get; set; }
    }
}
