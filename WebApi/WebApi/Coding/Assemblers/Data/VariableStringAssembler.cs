using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Assemblers.Data
{
    public interface IVariableStringAssembler
    {
        Interface.Coding.Dtos.Data.VariableString Assemble(VariableString variableString);

        VariableString Disassemble(Interface.Coding.Dtos.Data.VariableString variableStringDto);
    }

    public class VariableStringAssembler : IVariableStringAssembler
    {
        public Interface.Coding.Dtos.Data.VariableString Assemble(VariableString variableString)
        {
            return new Interface.Coding.Dtos.Data.VariableString { Name = variableString.Name };
        }

        public VariableString Disassemble(Interface.Coding.Dtos.Data.VariableString variableStringDto)
        {
            return new VariableString(variableStringDto.Name);
        }
    }
}
