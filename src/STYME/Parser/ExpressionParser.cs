using STYME.Expressions;
using STYME.Locale.English;
using STYME.Values.TimeShifts;

namespace STYME.Parser;

internal interface IExpressionParser
{
    IExpression? ParseExpressionTree(Queue<string> tokens);
}

internal sealed class ExpressionParser : IExpressionParser
{
    private readonly EnglishParserRules _rules;

    public ExpressionParser()
    {
        _rules = new EnglishParserRules();
    }

    public IExpression? ParseExpressionTree(Queue<string> tokens)
    {
        if (!tokens.TryDequeue(out var token))
        {
            return null;
        }

        if (_rules.TryGetExpressionConstructor(token, out var constructor) && constructor is not null)
        {
            return constructor.Construct(token, tokens, this);
        }

        if (double.TryParse(token, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var amount) && tokens.TryDequeue(out var unit))
        {
            var englishRules = _rules;
            if (englishRules.TryCreateTimeSpan(amount, unit, out _))
            {
                var shift = TimeShiftFactory.CreateFromUnit(amount, unit);
                return new TimeShiftExpression(shift);
            }

            tokens.Enqueue(unit);
            return null;
        }

        return null;
    }
}
