using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Assemblers.Data
{
    public interface IVariableIntAssembler
    {
        Interface.Coding.Dtos.Data.VariableInt Assemble(VariableInt variableInt);

        VariableInt Disassemble(Interface.Coding.Dtos.Data.VariableInt variableIntDto);
    }

    public class VariableIntAssembler : IVariableIntAssembler
    {
        public Interface.Coding.Dtos.Data.VariableInt Assemble(VariableInt variableInt)
        {
            return new Interface.Coding.Dtos.Data.VariableInt { Name = variableInt.Name };
        }

        public VariableInt Disassemble(Interface.Coding.Dtos.Data.VariableInt variableIntDto)
        {
            return new VariableInt(variableIntDto.Name);
        }
    }
}
