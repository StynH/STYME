using System;
using System.Collections.Generic;
using STYME.Expressions;
using STYME.Expressions.Implementations;

namespace STYME.Parser.Expressions.Constructors;

internal sealed class EndOfExpressionConstructor : IExpressionConstructor
{
    public IExpression Construct(string token, Queue<string> tokens, IExpressionParser parser)
    {
        ArgumentNullException.ThrowIfNull(tokens);

        var targetToken = ConsumeTarget(tokens) ?? throw new InvalidOperationException($"Expected a target after keyword '{token}'.");
        return new EndOfExpression(date => MoveToEnd(date, targetToken));
    }

    private static string? ConsumeTarget(Queue<string> tokens)
    {
        while (tokens.TryDequeue(out var candidate))
        {
            var trimmed = candidate.Trim();
            if (trimmed.Length == 0)
            {
                continue;
            }

            if (string.Equals(trimmed, "of", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (string.Equals(trimmed, "the", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            return trimmed;
        }

        return null;
    }

    private static DateTime MoveToEnd(DateTime current, string target)
    {
        if (string.Equals(target, "month", StringComparison.OrdinalIgnoreCase))
        {
            return MoveToEndOfMonth(current);
        }

        if (string.Equals(target, "year", StringComparison.OrdinalIgnoreCase))
        {
            return MoveToEndOfYear(current);
        }

        if (string.Equals(target, "week", StringComparison.OrdinalIgnoreCase))
        {
            return MoveToEndOfWeek(current);
        }

        throw new InvalidOperationException($"Unrecognised target '{target}' for end-of expression.");
    }

    private static DateTime MoveToEndOfMonth(DateTime current)
    {
        var daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);
        var startOfDay = new DateTime(current.Year, current.Month, daysInMonth, 0, 0, 0, current.Kind);
        return startOfDay.Add(current.TimeOfDay);
    }

    private static DateTime MoveToEndOfYear(DateTime current)
    {
        var startOfDay = new DateTime(current.Year, 12, 31, 0, 0, 0, current.Kind);
        return startOfDay.Add(current.TimeOfDay);
    }

    private static DateTime MoveToEndOfWeek(DateTime current)
    {
        const DayOfWeek weekEnd = DayOfWeek.Sunday;
        var daysUntil = ((int)weekEnd - (int)current.DayOfWeek + 7) % 7;
        var result = current.AddDays(daysUntil);
        return result;
    }
}

