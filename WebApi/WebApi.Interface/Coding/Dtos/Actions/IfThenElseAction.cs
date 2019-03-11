using WebApi.Interface.Coding.Dtos.Conditionals;

namespace WebApi.Interface.Coding.Dtos.Actions
{
    public class IfThenElseAction : IAction
    {
        public IConditional Conditional { get; set; }

        public IAction Action { get; set; }

        public IAction ElseAction { get; set; }
    }
}
