
public sealed class RoadIterator<T> : Iterator<T>
{
    public RoadIterator(T[] movePoints) : base(movePoints)
    {
    }

    public override bool MoveNext()
    {
        if (pointer + 1 < movePoints.Length)
        {
            pointer++;
            return true;
        }

        return false;
    }

    public override void Reset()
    {
        pointer = 0;
    }

    public override void Dispose()
    {
    }
}
