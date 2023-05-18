using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Projects;

public class LastProjectErrorDto : EntityDtoBase
{
    public int ProjectId { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProjectErrorCategory Category { get; set; }
    public string? Reason { get; set; }
}
