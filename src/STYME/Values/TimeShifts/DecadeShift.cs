using STYME.Handling;

namespace STYME.Values.TimeShifts;

internal sealed class DecadeShift : ITimeShift
{
    private readonly int _decades;

    public DecadeShift(int decades)
    {
        _decades = decades;
    }

    public IMutableTime Shift(IMutableTime dateTime)
    {
        return dateTime.AddYears(10 * _decades);
    }

    public ITimeShift Negate()
    {
        return new DecadeShift(-_decades);
    }
}
