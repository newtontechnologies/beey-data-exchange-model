using Beey.DataExchangeModel.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 8618
namespace Beey.DataExchangeModel.Projects;

public class ProjectMetadata : EntityBase
{
    public int ProjectId { get; set; }
    public string Key { get; set; }
    public string? Value { get; set; }
}
