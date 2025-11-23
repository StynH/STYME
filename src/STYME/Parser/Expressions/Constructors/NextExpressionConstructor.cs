using System;
using System.Collections.Generic;
using System.Linq;
using STYME.Expressions;
using STYME.Expressions.Implementations;
using STYME.Units;

namespace STYME.Parser.Expressions.Constructors;

internal sealed class NextExpressionConstructor : IExpressionConstructor
{
    private static readonly Dictionary<string, DayOfWeek> DaysOfWeekMap = Enum
        .GetValues<DayOfWeek>()
        .ToDictionary(d => d.ToString(), d => d, StringComparer.OrdinalIgnoreCase);

    private static readonly Dictionary<string, int> MonthMap = Enum
        .GetValues<Months>()
        .ToDictionary(m => m.ToString(), m => (int)m, StringComparer.OrdinalIgnoreCase);

    public IExpression Construct(string token, Queue<string> tokens, IExpressionParser parser)
    {
        ArgumentNullException.ThrowIfNull(tokens);

        if (!tokens.TryDequeue(out var targetToken))
        {
            throw new InvalidOperationException($"Expected a target after keyword '{token}'.");
        }

        var normalizedTarget = targetToken.Trim();
        if (DaysOfWeekMap.TryGetValue(normalizedTarget, out var dayOfWeek))
        {
            return new NextExpression(date => MoveToNextDayOfWeek(date, dayOfWeek));
        }

        if (MonthMap.TryGetValue(normalizedTarget, out var month))
        {
            return new NextExpression(date => MoveToNextMonth(date, month));
        }

        throw new InvalidOperationException($"Unrecognised target '{targetToken}' for keyword '{token}'.");
    }

    private static DateTime MoveToNextDayOfWeek(DateTime current, DayOfWeek target)
    {
        var daysUntil = ((int)target - (int)current.DayOfWeek + 7) % 7;
        if (daysUntil == 0)
        {
            daysUntil = 7;
        }

        return current.AddDays(daysUntil);
    }

    private static DateTime MoveToNextMonth(DateTime current, int targetMonth)
    {
        var targetYear = current.Month >= targetMonth ? current.Year + 1 : current.Year;
        var day = Math.Min(current.Day, DateTime.DaysInMonth(targetYear, targetMonth));
        var startOfTargetMonth = new DateTime(targetYear, targetMonth, day, 0, 0, 0, current.Kind);
        return startOfTargetMonth.Add(current.TimeOfDay);
    }
}

