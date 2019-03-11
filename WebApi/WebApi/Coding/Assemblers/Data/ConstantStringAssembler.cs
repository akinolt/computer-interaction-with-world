using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Assemblers.Data
{
    public interface IConstantStringAssembler
    {
        Interface.Coding.Dtos.Data.ConstantString Assemble(ConstantString constantString);

        ConstantString Disassemble(Interface.Coding.Dtos.Data.ConstantString constantStringDto);
    }

    public class ConstantStringAssembler : IConstantStringAssembler
    {
        public Interface.Coding.Dtos.Data.ConstantString Assemble(ConstantString constantString)
        {
            return new Interface.Coding.Dtos.Data.ConstantString { Value = constantString.Value };
        }

        public ConstantString Disassemble(Interface.Coding.Dtos.Data.ConstantString constantStringDto)
        {
            return new ConstantString(constantStringDto.Value);
        }
    }
}
