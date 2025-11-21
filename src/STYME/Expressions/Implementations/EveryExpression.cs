using System.Collections;
using STYME.Handling;
using STYME.Values.TimeShifts;

namespace STYME.Expressions.Implementations;

internal sealed class EveryExpression : IExpression
{
    private readonly IExpression _right;

    public EveryExpression(IExpression right)
    {
        _right = right;
    }

    public ExpressionResult ExecuteExpression(IMutableTime time)
    {
        var result = _right.ExecuteExpression(time);

        if (result.TryGet<ITimeShift>(out var shift))
        {
            return new ExpressionResult(new RecurringDateTimeEnumerable(time.ToExternal(), shift));
        }

        return ExpressionResult.Empty;
    }

    private sealed class RecurringDateTimeEnumerable : IEnumerable<DateTime>
    {
        private readonly DateTime _start;
        private readonly ITimeShift _shift;

        public RecurringDateTimeEnumerable(DateTime start, ITimeShift shift)
        {
            _start = start;
            _shift = shift;
        }

        public IEnumerator<DateTime> GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<DateTime> Enumerate()
        {
            IMutableTime current = new MutableDateTime(_start);

            while (true)
            {
                yield return current.ToExternal();
                current = _shift.Shift(current);
            }
        }
    }
}

