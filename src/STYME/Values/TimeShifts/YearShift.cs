using STYME.Handling;

namespace STYME.Values.TimeShifts;

internal sealed class YearShift : ITimeShift
{
    private readonly int _years;

    public YearShift(int years)
    {
        _years = years;
    }

    public IMutableTime Shift(IMutableTime dateTime)
    {
        return dateTime.AddYears(_years);
    }

    public ITimeShift Negate()
    {
        return new YearShift(-_years);
    }
}
