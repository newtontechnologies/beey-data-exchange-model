using Beey.DataExchangeModel.Serialization;
using Beey.DataExchangeModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Beey.DataExchangeModel.Projects;

/// <summary>
/// Each transcription have to be logged here
/// Will be used for computing total transcription time
/// length and settings have to be duplicated .. projects can be deleted
/// </summary>
public class TranscriptionLogItem : EntityBase
{
    public int TeamId { get; set; }
    public int UserId { get; set; }
    public string? Filename { get; set; }
    public int ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public decimal TranscribedMinutes { get; set; }
    public string? TranscriptionSettings { get; set; }
}
