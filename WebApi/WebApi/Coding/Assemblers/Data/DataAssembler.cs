using System;
using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Assemblers.Data
{
    public interface IDataAssembler
    {
        Interface.Coding.Dtos.Data.IData Assemble(IData data);

        IData Disassemble(Interface.Coding.Dtos.Data.IData dataDto);
    }

    public class DataAssembler : IDataAssembler
    {
        private readonly IConstantIntAssembler constantIntAssembler;
        private readonly IConstantStringAssembler constantStringAssembler;
        private readonly IVariableIntAssembler variableIntAssembler;
        private readonly IVariableStringAssembler variableStringAssembler;

        public DataAssembler(IConstantIntAssembler constantIntAssembler,
            IConstantStringAssembler constantStringAssembler,
            IVariableIntAssembler variableIntAssembler,
            IVariableStringAssembler variableStringAssembler)
        {
            this.constantIntAssembler = constantIntAssembler;
            this.constantStringAssembler = constantStringAssembler;
            this.variableIntAssembler = variableIntAssembler;
            this.variableStringAssembler = variableStringAssembler;
        }

        public Interface.Coding.Dtos.Data.IData Assemble(IData data)
        {
            var constantInt = data as ConstantInt;
            if (constantInt != null)
            {
                return this.constantIntAssembler.Assemble(constantInt);
            }

            var constantString = data as ConstantString;
            if (constantString != null)
            {
                return this.constantStringAssembler.Assemble(constantString);
            }

            var variableInt = data as VariableInt;
            if (variableInt != null)
            {
                return this.variableIntAssembler.Assemble(variableInt);
            }

            var variableString = data as VariableString;
            if (variableString != null)
            {
                return this.variableStringAssembler.Assemble(variableString);
            }

            // None of the IData types matches. We failed to disassmble.
            throw new Exception($"Unknown IAction type: {data.GetType().ToString()}");
        }

        public IData Disassemble(Interface.Coding.Dtos.Data.IData dataDto)
        {
            var constantIntDto = dataDto as Interface.Coding.Dtos.Data.ConstantInt;
            if (constantIntDto != null)
            {
                return this.constantIntAssembler.Disassemble(constantIntDto);
            }

            var constantStringDto = dataDto as Interface.Coding.Dtos.Data.ConstantString;
            if (constantStringDto != null)
            {
                return this.constantStringAssembler.Disassemble(constantStringDto);
            }

            var variableIntDto = dataDto as Interface.Coding.Dtos.Data.VariableInt;
            if (variableIntDto != null)
            {
                return this.variableIntAssembler.Disassemble(variableIntDto);
            }

            var variableStringDto = dataDto as Interface.Coding.Dtos.Data.VariableString;
            if (variableStringDto != null)
            {
                return this.variableStringAssembler.Disassemble(variableStringDto);
            }

            // None of the IData types matches. We failed to disassmble.
            throw new Exception($"Unknown IAction type: {dataDto.GetType().ToString()}");
        }
    }
}
