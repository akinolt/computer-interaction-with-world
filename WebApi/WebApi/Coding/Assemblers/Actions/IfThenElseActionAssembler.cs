using WebApi.Coding.Assemblers.Conditionals;
using WebApi.Coding.Domain.Actions;

namespace WebApi.Coding.Assemblers.Actions
{
    public interface IIfThenElseActionAssembler
    {
        Interface.Coding.Dtos.Actions.IfThenElseAction Assemble(IfThenElseAction ifThenElseAction);

        IfThenElseAction Disassemble(Interface.Coding.Dtos.Actions.IfThenElseAction ifThenElseActionDto);
    }

    public class IfThenElseActionAssembler : IIfThenElseActionAssembler
    {
        private readonly IConditionalAssembler conditionalAssembler;

        private readonly IActionAssembler actionAssembler;

        public IfThenElseActionAssembler(IConditionalAssembler conditionalAssembler, IActionAssembler actionAssembler)
        {
            this.conditionalAssembler = conditionalAssembler;
            this.actionAssembler = actionAssembler;
        }

        public Interface.Coding.Dtos.Actions.IfThenElseAction Assemble(IfThenElseAction ifThenElseAction)
        {
            return new Interface.Coding.Dtos.Actions.IfThenElseAction
            {
                Conditional = this.conditionalAssembler.Assemble(ifThenElseAction.Conditional),
                Action = this.actionAssembler.Assemble(ifThenElseAction.Action),
                ElseAction = this.actionAssembler.Assemble(ifThenElseAction.ElseAction)
            };
        }

        public IfThenElseAction Disassemble(Interface.Coding.Dtos.Actions.IfThenElseAction ifThenElseActionDto)
        {
            return new IfThenElseAction(this.conditionalAssembler.Disassemble(ifThenElseActionDto.Conditional), this.actionAssembler.Disassemble(ifThenElseActionDto.Action), this.actionAssembler.Disassemble(ifThenElseActionDto.ElseAction));
        }
    }
}
