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
        public int CreditMinutes { get; set; }
        public decimal TranscribedMinutes { get; set; }
        public bool DidPay { get; set; }
        public JArray CustomProjectTags { get; set; }

        public enum OrderMembersBy { Email, TranscribedMinutes }
    }

    public class WorkspaceStandardViewModel : WorkspaceViewModel
    {
        public class Member
        {
            public int Id { get; set; }
            public string Email { get; set; }
        }

        public IEnumerable<Member> Members { get; set; }
    }

    public class WorkspaceAdminViewModel : WorkspaceViewModel
    {
        public class Member
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public decimal? Transcribed { get; set; }
            public DateTime? From { get; set; }
            public DateTime? To { get; set; }
        }

        public IEnumerable<Member> Members { get; set; }
    }
}
