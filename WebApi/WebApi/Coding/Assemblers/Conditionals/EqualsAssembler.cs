using WebApi.Coding.Assemblers.Data;
using WebApi.Coding.Domain.Conditionals;

namespace WebApi.Coding.Assemblers.Conditionals
{
    public interface IEqualsAssembler
    {
        Interface.Coding.Dtos.Conditionals.Equals Assemble(Equals equals);

        Equals Disassemble(Interface.Coding.Dtos.Conditionals.Equals equalsDto);
    }

    public class EqualsAssembler : IEqualsAssembler
    {
        private readonly IDataAssembler dataAssembler;

        public EqualsAssembler(IDataAssembler dataAssembler)
        {
            this.dataAssembler = dataAssembler;
        }

        public Interface.Coding.Dtos.Conditionals.Equals Assemble(Equals equals)
        {
            return new Interface.Coding.Dtos.Conditionals.Equals { Value1 = this.dataAssembler.Assemble(equals.Value1), Value2 = this.dataAssembler.Assemble(equals.Value2) };
        }

        public Equals Disassemble(Interface.Coding.Dtos.Conditionals.Equals equalsDto)
        {
            return new Equals(this.dataAssembler.Disassemble(equalsDto.Value1), this.dataAssembler.Disassemble(equalsDto.Value2));
        }
    }
}
