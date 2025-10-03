using STYME.Expressions;
using STYME.Expressions.Implementations;

namespace STYME.Parser.Expressions.Constructors;

internal sealed class DeductExpressionConstructor : IExpressionConstructor
{
    public IExpression Construct(string token, Queue<string> tokens, IExpressionParser parser)
    {
        var right = parser.ParseExpressionTree(tokens) ?? throw new InvalidOperationException($"Expected expression after keyword '{token}'.");
        return new DeductExpression(right);
    }
}
