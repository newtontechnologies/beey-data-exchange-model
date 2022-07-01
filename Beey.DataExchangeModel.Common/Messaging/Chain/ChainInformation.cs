namespace Backend.Messaging.Chain;

public class ChainInformation
{
    public ChainInformation(int projectId, int userId)
    {
        ProjectId = projectId;
        CreatorUserId = userId;
    }

    private static int s_chainId = 0;
    public int ChainId { get; } = Interlocked.Increment(ref s_chainId);

    public int ProjectId { get; }
    public int CreatorUserId { get; }
}
