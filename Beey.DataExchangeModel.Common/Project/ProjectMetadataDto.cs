using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Text;


namespace Beey.DataExchangeModel.Projects;

public class ProjectMetadataDto : EntityDtoBase
{
    public int ProjectId { get; set; }
    public string Key { get; set; }
    public string? Value { get; set; }
}
