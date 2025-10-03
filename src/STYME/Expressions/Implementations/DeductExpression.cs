using STYME.Handling;
using STYME.Values.TimeShifts;

namespace STYME.Expressions.Implementations;

internal sealed class DeductExpression : IExpression
{
    private readonly IExpression _right;

    public DeductExpression(IExpression right)
    {
        _right = right;
    }

    public ExpressionResult ExecuteExpression(IMutableTime time)
    {
        var result = _right.ExecuteExpression(time);
        if (result.TryGet<ITimeShift>(out var timeShift))
        {
            return new ExpressionResult(timeShift.Negate().Shift(time));
        }

        return ExpressionResult.Empty;
    }
}
