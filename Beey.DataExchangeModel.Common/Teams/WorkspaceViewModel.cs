using Beey.DataExchangeModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Workspaces;

public class WorkspaceViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int CreditMinutes { get; set; }
    public decimal TranscribedMinutes { get; set; }
    public bool DidPay { get; set; }
    public JsonArray CustomProjectTags { get; set; }
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
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
    }

    public IEnumerable<Member> Members { get; set; }
}
