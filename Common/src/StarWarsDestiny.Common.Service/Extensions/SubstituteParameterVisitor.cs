using System.Collections.Generic;
using System.Linq.Expressions;

namespace StarWarsDestiny.Common.Service.Extensions
{
    internal class SubstituteParameterVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> Sub = new Dictionary<Expression, Expression>();

        protected override Expression VisitParameter(ParameterExpression node) =>
            Sub.TryGetValue(node, out var newValue) ? newValue : node;
    }
}
