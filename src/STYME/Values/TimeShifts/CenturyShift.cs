using STYME.Handling;

namespace STYME.Values.TimeShifts;

internal sealed class CenturyShift : ITimeShift
{
    private readonly int _centuries;

    public CenturyShift(int centuries)
    {
        _centuries = centuries;
    }

    public IMutableTime Shift(IMutableTime dateTime)
    {
        return dateTime.AddYears(100 * _centuries);
    }

    public ITimeShift Negate()
    {
        return new CenturyShift(-_centuries);
    }
}
