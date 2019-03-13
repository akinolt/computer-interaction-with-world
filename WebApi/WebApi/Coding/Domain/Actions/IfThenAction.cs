using System.Collections.Generic;
using WebApi.Coding.Domain.Conditionals;
using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Domain.Actions
{
    public class IfThenAction : IAction
    {
        public IfThenAction(IConditional conditional, IAction action)
        {
            this.Conditional = conditional;
            this.Action = action;
        }

        public IConditional Conditional { get; }

        public IAction Action { get; }

        public void Act()
        {
            if (Conditional.Evaluate())
            {
                Action.Act();
            }
        }
    }
}
