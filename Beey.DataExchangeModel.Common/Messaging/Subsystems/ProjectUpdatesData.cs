using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Common.Messaging.Subsystems;

public enum Changed { KeywordsHighlight }

public class ProjectUpdatesData : SubsystemData<ProjectUpdatesData>
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Changed Changed { get; set; }
}
