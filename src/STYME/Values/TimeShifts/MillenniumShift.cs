using STYME.Handling;

namespace STYME.Values.TimeShifts;

internal sealed class MillenniumShift : ITimeShift
{
    private readonly int _millennia;

    public MillenniumShift(int millennia)
    {
        _millennia = millennia;
    }

    public IMutableTime Shift(IMutableTime dateTime)
    {
        return dateTime.AddYears(1000 * _millennia);
    }

    public ITimeShift Negate()
    {
        return new MillenniumShift(-_millennia);
    }
}
