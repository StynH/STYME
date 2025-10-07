using STYME.Parser.Expressions;

namespace STYME.Locale;

internal abstract class ParserRules
{
    protected ParserRules()
    {
    }

    public abstract bool TryGetExpressionConstructor(string token, out IExpressionConstructor? constructor);

    public virtual bool IsConjunction(string token)
    {
        return false;
    }
}
