using System;
using WebApi.Coding.Domain.Conditionals;

namespace WebApi.Coding.Assemblers.Conditionals
{
    public interface IConditionalAssembler
    {
        Interface.Coding.Dtos.Conditionals.IConditional Assemble(IConditional conditional);

        IConditional Disassemble(Interface.Coding.Dtos.Conditionals.IConditional conditionalDto);
    }

    public class ConditionalAssembler : IConditionalAssembler
    {
        private readonly IEqualsAssembler equalsAssembler;

        public ConditionalAssembler(IEqualsAssembler equalsAssembler)
        {
            this.equalsAssembler = equalsAssembler;
        }

        public Interface.Coding.Dtos.Conditionals.IConditional Assemble(IConditional conditional)
        {
            var equals = conditional as Domain.Conditionals.Equals;
            if (equals != null)
            {
                return this.equalsAssembler.Assemble(equals);
            }

            // None of the IConditional types matches. We failed to disassmble.
            throw new Exception($"Unknown IConditional type: {conditional.GetType().ToString()}");
        }

        public IConditional Disassemble(Interface.Coding.Dtos.Conditionals.IConditional conditionalDto)
        {
            var equalsDto = conditionalDto as Interface.Coding.Dtos.Conditionals.Equals;
            if (equalsDto != null)
            {
                return this.equalsAssembler.Disassemble(equalsDto);
            }

            // None of the IConditional types matches. We failed to disassmble.
            throw new Exception($"Unknown IConditional type: {conditionalDto.GetType().ToString()}");
        }
    }
}
