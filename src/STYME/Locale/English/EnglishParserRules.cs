using STYME.Parser.Expressions;
using STYME.Parser.Expressions.Constructors;

namespace STYME.Locale.English;

internal sealed class EnglishParserRules : ParserRules
{
    private readonly Dictionary<string, Func<double, TimeSpan>> _timeUnitMap;
    private readonly Dictionary<string, IExpressionConstructor> _constructors;

    public EnglishParserRules()
    {
        _timeUnitMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["second"] = TimeSpan.FromSeconds,
            ["seconds"] = TimeSpan.FromSeconds,
            ["minute"] = TimeSpan.FromMinutes,
            ["minutes"] = TimeSpan.FromMinutes,
            ["hour"] = TimeSpan.FromHours,
            ["hours"] = TimeSpan.FromHours,
            ["day"] = TimeSpan.FromDays,
            ["days"] = TimeSpan.FromDays,
            ["week"] = v => TimeSpan.FromDays(v * 7),
            ["weeks"] = v => TimeSpan.FromDays(v * 7),
            ["month"] = v => TimeSpan.FromDays(v * 30),
            ["months"] = v => TimeSpan.FromDays(v * 30),
            ["year"] = v => TimeSpan.FromDays(v * 365),
            ["years"] = v => TimeSpan.FromDays(v * 365),
            ["decade"] = v => TimeSpan.FromDays(v * 365 * 10),
            ["decades"] = v => TimeSpan.FromDays(v * 365 * 10),
            ["century"] = v => TimeSpan.FromDays(v * 365 * 100),
            ["centuries"] = v => TimeSpan.FromDays(v * 365 * 100),
            ["millennium"] = v => TimeSpan.FromDays(v * 365 * 1000),
            ["millennia"] = v => TimeSpan.FromDays(v * 365 * 1000)
        };

        _constructors = new(StringComparer.OrdinalIgnoreCase)
        {
            ["add"] = new AddExpressionConstructor()
        };
    }

    public bool TryCreateTimeSpan(double amount, string unit, out TimeSpan value)
    {
        if (unit is null)
        {
            value = default;
            return false;
        }

        if (_timeUnitMap.TryGetValue(unit.Trim(), out var converter))
        {
            value = converter(amount);
            return true;
        }

        value = default;
        return false;
    }

    public override bool TryGetExpressionConstructor(string token, out IExpressionConstructor? constructor)
    {
        if (token is null)
        {
            constructor = null;
            return false;
        }

        return _constructors.TryGetValue(token.Trim(), out constructor);
    }
}
