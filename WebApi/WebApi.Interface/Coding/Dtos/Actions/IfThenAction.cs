using WebApi.Interface.Coding.Dtos.Conditionals;

namespace WebApi.Interface.Coding.Dtos.Actions
{
    public class IfThenAction : IAction
    {
        public IConditional Conditional { get; set; }

        public IAction Action { get; set; }
    }
}
