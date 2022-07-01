using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;


namespace Backend.Messaging.Chain;

public sealed class SubsystemNodeIndex : IComparable<SubsystemNodeIndex>, IEquatable<SubsystemNodeIndex>
{
    public ImmutableArray<int> Index { get; }

    public SubsystemNodeIndex(int[] index)
    {
        Index = index.ToImmutableArray();
    }
    public SubsystemNodeIndex(ImmutableArray<int> index)
    {
        Index = index;
    }

    public SubsystemNodeIndex(int ix)
    {
        Index = new[] { ix }.ToImmutableArray();
    }

    public SubsystemNodeIndex()
    {
        Index = ImmutableArray<int>.Empty;
    }

    public static implicit operator SubsystemNodeIndex(int ix) => new SubsystemNodeIndex(ix);
    public static implicit operator SubsystemNodeIndex(int[] ix) => new SubsystemNodeIndex(ix);
    public static implicit operator SubsystemNodeIndex(ImmutableArray<int> ix) => new SubsystemNodeIndex(ix);

    public static SubsystemNodeIndex operator +(SubsystemNodeIndex left, SubsystemNodeIndex right) => new SubsystemNodeIndex(left.Index.Concat(right.Index).ToArray());

    public int CompareTo([AllowNull] SubsystemNodeIndex other)
    {
        if (other is null)
            return 1;

        var mlength = Math.Min(other.Index.Length, Index.Length);

        for (int i = 0; i < mlength; i++)
        {
            if (Index[i] < other.Index[i])
                return -1;

            if (Index[i] > other.Index[i])
                return -1;
        }

        throw new InvalidOperationException("Onde of indexes in not leave index or indexes are not from same chain");
    }

    public bool Equals([AllowNull] SubsystemNodeIndex other) =>
        ReferenceEquals(this, other)
        ||
        (other is { } o
        && o.Index.Length == Index.Length
        && o.Index.Zip(Index, (l, r) => l == r).All(c => c));

    public override bool Equals(object? obj) => Equals(obj as SubsystemNodeIndex);

    public override int GetHashCode() => Index.Length == 0 ? 0.GetHashCode() : Index.Aggregate((x, a) => HashCode.Combine(x, a));

    public static bool operator ==(SubsystemNodeIndex left, SubsystemNodeIndex right)
    {
        if (left is null)
            return right is null;

        return left.Equals(right);
    }

    public static bool operator !=(SubsystemNodeIndex left, SubsystemNodeIndex right) => !(left == right);

    public static bool operator <(SubsystemNodeIndex left, SubsystemNodeIndex right)
    {
        return left is null ? right is object : left.CompareTo(right) < 0;
    }

    public static bool operator <=(SubsystemNodeIndex left, SubsystemNodeIndex right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(SubsystemNodeIndex left, SubsystemNodeIndex right)
    {
        return left is object && left.CompareTo(right) > 0;
    }

    public static bool operator >=(SubsystemNodeIndex left, SubsystemNodeIndex right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }

    public static implicit operator ImmutableArray<int>(SubsystemNodeIndex v)
        => v.Index;

    public static bool IsSameGroup(SubsystemNodeIndex left, SubsystemNodeIndex right)
    {
        if (left is null || right is null)
            return false;

        if (left.Index.Length != right.Index.Length)
            return false;

        for (int i = 0; i < left.Index.Length - 2; i++)
        {
            if (left.Index[i] != right.Index[i])
                return false;
        }

        return true;
    }
}
