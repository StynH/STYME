using STYME.Handling;

namespace STYME.Values.TimeShifts;

internal sealed class TimeSpanShift : ITimeShift
{
    private readonly TimeSpan _value;

    public TimeSpanShift(TimeSpan value)
    {
        _value = value;
    }

    public IMutableTime Shift(IMutableTime dateTime)
    {
        return dateTime.Add(_value);
    }

    public ITimeShift Negate()
    {
        return new TimeSpanShift(-_value);
    }
}
