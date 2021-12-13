using Beey.DataExchangeModel.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Teams
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int CreditMinutes { get; set; }
        public decimal TranscribedMinutes { get; set; }
        public bool DidPay { get; set; }
        public JArray CustomProjectTags { get; set; }
        public int MemberCount { get; set; }
    }

    public class TeamStandardViewModel : TeamViewModel
    {
        public class Member
        {
            public int Id { get; set; }
            public string Email { get; set; }
        }

        public IEnumerable<Member> Members { get; set; }
    }

    public class TeamAdminViewModel : TeamViewModel
    {
        public class Member
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public decimal? Transcribed { get; set; }
            public DateTimeOffset? From { get; set; }
            public DateTimeOffset? To { get; set; }
        }

        public decimal TranscribedMinutesPerPeriod { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
