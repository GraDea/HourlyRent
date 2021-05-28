using System.Linq.Expressions;

namespace HourlyRate.Utility
{
    public class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;


        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }


        public override Expression Visit(Expression ex)
        {
            if (ex == from) return to;
            else return base.Visit(ex);
        }
    }
}