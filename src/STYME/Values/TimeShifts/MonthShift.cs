using STYME.Handling;

namespace STYME.Values.TimeShifts;

internal sealed class MonthShift : ITimeShift
{
    private readonly int _months;

    public MonthShift(int months)
    {
        _months = months;
    }

    public IMutableTime Shift(IMutableTime dateTime)
    {
        return dateTime.AddMonths(_months);
    }

    public ITimeShift Negate()
    {
        return new MonthShift(-_months);
    }
}
