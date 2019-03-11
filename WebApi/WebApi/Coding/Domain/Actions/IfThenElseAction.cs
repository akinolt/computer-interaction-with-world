using WebApi.Coding.Domain.Conditionals;

namespace WebApi.Coding.Domain.Actions
{
    public class IfThenElseAction : IAction
    {
        public IfThenElseAction(IConditional conditional, IAction action, IAction elseAction)
        {
            this.Conditional = conditional;
            this.Action = action;
            this.ElseAction = elseAction;
        }

        public IConditional Conditional { get; }

        public IAction Action { get; }

        public IAction ElseAction { get; }

        public void Act()
        {
            if (this.Conditional.Evaluate())
            {
                this.Action.Act();
            }
            else
            {
                this.ElseAction.Act();
            }
        }
    }
}
