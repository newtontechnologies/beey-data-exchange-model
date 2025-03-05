using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Common.Messaging.Subsystems;

public enum Changed { KeywordsHighlight, Tags, Metadata, Checklist }

public class ProjectUpdatesData : SubsystemData<ProjectUpdatesData>
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Changed Changed { get; set; }
}
