using STYME.Parser.Expressions;
using STYME.Parser.Expressions.Constructors;

namespace STYME.Locale.English;

internal sealed class EnglishParserRules : ParserRules
{
    private readonly Dictionary<string, Func<double, TimeSpan>> _timeUnitMap;
    private readonly Dictionary<string, IExpressionConstructor> _constructors;

    public EnglishParserRules()
    {
        _timeUnitMap = new(StringComparer.OrdinalIgnoreCase);
        AddTimeUnitAliases(TimeSpan.FromSeconds, "second", "seconds");
        AddTimeUnitAliases(TimeSpan.FromMinutes, "minute", "minutes");
        AddTimeUnitAliases(TimeSpan.FromHours, "hour", "hours");
        AddTimeUnitAliases(TimeSpan.FromDays, "day", "days");
        AddTimeUnitAliases(v => TimeSpan.FromDays(v * 7), "week", "weeks");
        AddTimeUnitAliases(v => TimeSpan.FromDays(v * 30), "month", "months");
        AddTimeUnitAliases(v => TimeSpan.FromDays(v * 365), "year", "years");
        AddTimeUnitAliases(v => TimeSpan.FromDays(v * 365 * 10), "decade", "decades");
        AddTimeUnitAliases(v => TimeSpan.FromDays(v * 365 * 100), "century", "centuries");
        AddTimeUnitAliases(v => TimeSpan.FromDays(v * 365 * 1000), "millennium", "millennia", "millenium");

        _constructors = new(StringComparer.OrdinalIgnoreCase);
        AddConstructorAliases(new AddExpressionConstructor(), "add");
        AddConstructorAliases(new DeductExpressionConstructor(), "deduct", "subtract");
    }

    private void AddConstructorAliases(IExpressionConstructor constructor, params string[] names)
    {
        foreach (var name in names)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                continue;
            }

            _constructors[name.Trim()] = constructor;
        }
    }
    private void AddTimeUnitAliases(Func<double, TimeSpan> converter, params string[] names)
    {
        foreach (var name in names)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                continue;
            }

            _timeUnitMap[name.Trim()] = converter;
        }
    }

    public bool TryCreateTimeSpan(double amount, string unit, out TimeSpan value)
    {
        if (string.IsNullOrWhiteSpace(unit))
        {
            value = default;
            return false;
        }

        var key = unit.Trim();
        if (_timeUnitMap.TryGetValue(key, out var converter))
        {
            value = converter(amount);
            return true;
        }

        value = default;
        return false;
    }

    public override bool TryGetExpressionConstructor(string token, out IExpressionConstructor? constructor)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            constructor = null;
            return false;
        }

        return _constructors.TryGetValue(token.Trim(), out constructor);
    }

    public override bool IsConjunction(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return false;
        }

        return string.Equals(token.Trim(), "and", StringComparison.OrdinalIgnoreCase);
    }
}
