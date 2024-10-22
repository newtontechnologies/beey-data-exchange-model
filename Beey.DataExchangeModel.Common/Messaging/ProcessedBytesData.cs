using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Common.Messaging;

public class ProcessedBytesData : SubsystemData<ProcessedBytesData>
{
    public long ByteCount { get; init; }
}
