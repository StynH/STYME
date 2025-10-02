namespace STYME.Handling;

internal sealed class MutableDateTime : IMutableTime
{
    public MutableDateTime(DateTime value)
    {
        Value = value;
    }

    public DateTime Value { get; }

    public IMutableTime Add(TimeSpan value)
    {
        return new MutableDateTime(Value.Add(value));
    }

    public IMutableTime AddMonths(int months)
    {
        return new MutableDateTime(Value.AddMonths(months));
    }

    public IMutableTime AddYears(int years)
    {
        return new MutableDateTime(Value.AddYears(years));
    }

    public DateTime ToExternal()
    {
        return Value;
    }

    public override string ToString()
    {
        return Value.ToString("o");
    }
}
