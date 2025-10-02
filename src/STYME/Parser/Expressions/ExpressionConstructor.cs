using STYME.Expressions;

namespace STYME.Parser.Expressions;

internal interface IExpressionConstructor
{
    IExpression Construct(string token, Queue<string> tokens, IExpressionParser parser);
}
