namespace WebApi.Coding.Actions
{
    public class IfThenElseAction : IAction
    {
        private IConditional conditional;

        private IAction action;

        private IAction elseAction;

        public IfThenElseAction(IConditional conditional, IAction action, IAction elseAction)
        {
            this.conditional = conditional;
            this.action = action;
            this.elseAction = elseAction;
        }

        public void Act()
        {
            if (conditional.Evaluate())
            {
                action.Act();
            }
            else
            {
                elseAction.Act();
            }
        }
    }
}
