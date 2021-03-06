using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DoomSharp
{
    public sealed class LogicalXorExpression : BinaryExpression
    {
        public LogicalXorExpression(Expression left,Expression right) : base(left,right)
        {
        }

        public override Type Evaluate(CodeContext c)
        {
            Type lefttype = Left.Evaluate(c);
            Type righttype = Right.Evaluate(c);
            if (lefttype != typeof(bool) || righttype != typeof(bool))
            {
                throw new ApplicationException();
            }
            c.IL.Emit(OpCodes.Xor);
            return typeof(bool);
        }
    }
}
