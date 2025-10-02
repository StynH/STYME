using STYME.Handling;
using STYME.Parser;

namespace STYME;

public class NaturalDateTime
{
    private readonly IMutableTime _mutableTime;
    private readonly ExpressionParser _expressionParser;

    public NaturalDateTime() : this(new MutableDateTime(DateTime.Now))
    {
    }

    private NaturalDateTime(IMutableTime mutableTime)
    {
        _mutableTime = mutableTime;
        _expressionParser = new ExpressionParser();
    }

    public static NaturalDateTime From(DateTime dateTime)
    {
        return new(new MutableDateTime(dateTime));
    }

    public DateTime Parse(string value)
    {
        var tokens = new Queue<string>(value.Split(' '));
        var root = _expressionParser.ParseExpressionTree(tokens)!;

        var result = root.ExecuteExpression(_mutableTime);
        if(result.TryGet<IMutableTime>(out var mutableTime))
        {
            return mutableTime.ToExternal();
        }

        //TODO: Placeholder.
        return DateTime.Now;
    }
}
