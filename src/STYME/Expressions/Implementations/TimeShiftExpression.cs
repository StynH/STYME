using STYME.Handling;
using STYME.Values.TimeShifts;

namespace STYME.Expressions.Implementations;

internal sealed class TimeShiftExpression : IExpression
{
    private readonly ITimeShift _shift;

    public TimeShiftExpression(ITimeShift shift)
    {
        _shift = shift;
    }

    public ExpressionResult ExecuteExpression(IMutableTime time)
    {
        return new ExpressionResult(_shift);
    }
}

