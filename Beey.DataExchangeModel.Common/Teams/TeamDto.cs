
using Beey.DataExchangeModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Teams;

public class TeamDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int CreditMinutes { get; set; }
    public decimal TranscribedMinutes { get; set; }
    public bool DidPay { get; set; }
    public JsonArray CustomProjectTags { get; set; } = new();
    public int MemberCount { get; set; }
    public JsonObject? Settings { get; set; }
    public TimeSpan? AbandonProjectsIn { get; set; }
}

public class TeamDtoStandard : TeamDto
{
    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public IEnumerable<Member> Members { get; set; }
}

public class TeamDtoAdmin : TeamDto
{
    public class Member
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public decimal? Transcribed { get; set; }
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
    }

    public decimal TranscribedMinutesPerPeriod { get; set; }
    public IEnumerable<Member> Members { get; set; }

    public string? ManagementGroup { get; set; }
    public int? ManagementGroupId { get; set; }
}
