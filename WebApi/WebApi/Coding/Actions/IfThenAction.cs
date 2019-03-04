namespace WebApi.Coding.Actions
{
    public class IfThenAction : IAction
    {
        private IConditional conditional;

        private IAction action;

        public IfThenAction(IConditional conditional, IAction action)
        {
            this.conditional = conditional;
            this.action = action;
        }

        public void Act()
        {
            if (conditional.Evaluate())
            {
                action.Act();
            }
        }
    }
}
