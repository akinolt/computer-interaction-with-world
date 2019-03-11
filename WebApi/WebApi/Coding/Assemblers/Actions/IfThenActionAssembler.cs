using WebApi.Coding.Assemblers.Conditionals;
using WebApi.Coding.Domain.Actions;

namespace WebApi.Coding.Assemblers.Actions
{
    public interface IIfThenActionAssembler
    {
        Interface.Coding.Dtos.Actions.IfThenAction Assemble(IfThenAction ifThenAction);

        IfThenAction Disassemble(Interface.Coding.Dtos.Actions.IfThenAction ifThenActionDto);
    }

    public class IfThenActionAssembler : IIfThenActionAssembler
    {
        private readonly IConditionalAssembler conditionalAssembler;

        private readonly IActionAssembler actionAssembler;

        public IfThenActionAssembler(IConditionalAssembler conditionalAssembler, IActionAssembler actionAssembler)
        {
            this.conditionalAssembler = conditionalAssembler;
            this.actionAssembler = actionAssembler;
        }

        public Interface.Coding.Dtos.Actions.IfThenAction Assemble(IfThenAction ifThenAction)
        {
            return new Interface.Coding.Dtos.Actions.IfThenAction
            {
                Conditional = this.conditionalAssembler.Assemble(ifThenAction.Conditional),
                Action = this.actionAssembler.Assemble(ifThenAction.Action)
            };
        }

        public IfThenAction Disassemble(Interface.Coding.Dtos.Actions.IfThenAction ifThenActionDto)
        {
            return new IfThenAction(this.conditionalAssembler.Disassemble(ifThenActionDto.Conditional), this.actionAssembler.Disassemble(ifThenActionDto.Action));
        }
    }
}
