using STYME.Handling;

namespace STYME.Values.TimeShifts;

internal interface ITimeShift
{
    IMutableTime Shift(IMutableTime dateTime);

    ITimeShift Negate();
}
