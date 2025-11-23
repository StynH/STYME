using System;
using STYME.Handling;

namespace STYME.Expressions.Implementations;

internal sealed class NextExpression : IExpression
{
    private readonly Func<DateTime, DateTime> _resolver;

    public NextExpression(Func<DateTime, DateTime> resolver)
    {
        ArgumentNullException.ThrowIfNull(resolver);
        _resolver = resolver;
    }

    public ExpressionResult ExecuteExpression(IMutableTime time)
    {
        ArgumentNullException.ThrowIfNull(time);

        var nextDate = _resolver(time.ToExternal());
        return new ExpressionResult(new MutableDateTime(nextDate));
    }
}

