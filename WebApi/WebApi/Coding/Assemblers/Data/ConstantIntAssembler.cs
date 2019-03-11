using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Assemblers.Data
{
    public interface IConstantIntAssembler
    {
        Interface.Coding.Dtos.Data.ConstantInt Assemble(ConstantInt constantInt);

        ConstantInt Disassemble(Interface.Coding.Dtos.Data.ConstantInt constantIntDto);
    }

    public class ConstantIntAssembler : IConstantIntAssembler
    {
        public Interface.Coding.Dtos.Data.ConstantInt Assemble(ConstantInt constantInt)
        {
            return new Interface.Coding.Dtos.Data.ConstantInt { Value = constantInt.Value };
        }

        public ConstantInt Disassemble(Interface.Coding.Dtos.Data.ConstantInt constantIntDto)
        {
            return new ConstantInt(constantIntDto.Value);
        }
    }
}
