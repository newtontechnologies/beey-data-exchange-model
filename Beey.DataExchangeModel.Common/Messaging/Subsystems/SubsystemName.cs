namespace Beey.DataExchangeModel.Messaging.Subsystems;

public readonly struct SubsystemName : IEquatable<SubsystemName>
{
    public readonly string RawName { get; }

    private SubsystemName(string subsystemName)
    {
        RawName = subsystemName;
    }

    /// <summary>
    /// Subsystem names should be used from values in KnownSubsystem(Name)s not by constructing it directly
    /// </summary>
    /// <param name="subsystemName"></param>
    /// <returns></returns>
    public static SubsystemName Get(string subsystemName)
        => new SubsystemName(subsystemName);

    public override readonly int GetHashCode()
    {
        return RawName.GetHashCode();
    }

    public readonly bool Equals(SubsystemName other)
        => string.Equals(RawName, other.RawName);

    public static bool operator ==(SubsystemName? left, SubsystemName? right)
        => SubsystemName.Equals(left, right);


    public static bool operator !=(SubsystemName? left, SubsystemName? right)
        => !SubsystemName.Equals(left, right);

    public override readonly string ToString()
        => RawName;

    public override bool Equals(object? obj)
        => obj is SubsystemName name && Equals(name);
}
