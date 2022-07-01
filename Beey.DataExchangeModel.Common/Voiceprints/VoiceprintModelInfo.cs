using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Voiceprints;

public class VoiceprintModelInfo
{
    public VoiceprintModelInfo() { }
    public VoiceprintModelInfo(string hash, float acceptanceThreshold)
    {
        Hash = hash;
        AcceptanceThreshold = acceptanceThreshold;
    }

    public string Hash { get; set; }
    public float AcceptanceThreshold { get; set; }
}
