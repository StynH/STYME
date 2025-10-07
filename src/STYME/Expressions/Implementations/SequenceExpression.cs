using STYME.Handling;
using STYME.Values.TimeShifts;

namespace STYME.Expressions.Implementations;

internal sealed class SequenceExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public SequenceExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public ExpressionResult ExecuteExpression(IMutableTime time)
    {
        var leftResult = _left.ExecuteExpression(time);

        ExpressionResult EvaluateRight(IMutableTime nextTime)
        {
            var rightResult = _right.ExecuteExpression(nextTime);

            if (rightResult.TryGet<IMutableTime>(out var resultMutable))
            {
                return new ExpressionResult(resultMutable);
            }

            if (rightResult.TryGet<ITimeShift>(out var resultShift))
            {
                return new ExpressionResult(resultShift.Shift(nextTime));
            }

            return ExpressionResult.Empty;
        }

        if (leftResult.TryGet<IMutableTime>(out var mutable))
        {
            return EvaluateRight(mutable);
        }

        if (leftResult.TryGet<ITimeShift>(out var timeShift))
        {
            var shifted = timeShift.Shift(time);
            return EvaluateRight(shifted);
        }

        return ExpressionResult.Empty;
    }
}
