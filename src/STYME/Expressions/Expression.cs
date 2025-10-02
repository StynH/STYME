using STYME.Handling;

namespace STYME.Expressions;

internal interface IExpression
{
    ExpressionResult ExecuteExpression(IMutableTime time);
}
