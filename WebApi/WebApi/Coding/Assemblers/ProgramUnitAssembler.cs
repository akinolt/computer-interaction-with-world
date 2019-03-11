////using System;
////using WebApi.Coding.Assemblers.Actions;
////using WebApi.Coding.Assemblers.Data;
////using WebApi.Interface.Coding.Dtos;

////namespace WebApi.Coding.Assemblers
////{
////    public interface IProgramUnitAssembler
////    {
////        IProgramUnit Disassemble(Interface.Coding.Dtos.IProgramUnit programUnitDto);
////    }

////    public class ProgramUnitAssembler : IProgramUnitAssembler
////    {
////        private readonly IActionAssembler actionAssembler;

////        private readonly IDataAssembler dataAssembler;

////        public ProgramUnitAssembler(IActionAssembler actionAssembler, IDataAssembler dataAssembler)
////        {
////            this.actionAssembler = actionAssembler;
////            this.dataAssembler = dataAssembler;
////        }

////        public IProgramUnit Disassemble(Interface.Coding.Dtos.IProgramUnit programUnitDto)
////        {
////            var actionDto = programUnitDto as Interface.Coding.Dtos.Actions.IAction;
////            if (actionDto != null)
////            {
////                return this.actionAssembler.Disassemble(actionDto);
////            }

////            var dataDto = programUnitDto as Interface.Coding.Dtos.Data.IData;
////            if (dataDto != null)
////            {
////                return this.dataAssembler.Disassemble(dataDto);
////            }

////            // None of the IData types matches. We failed to disassmble.
////            throw new Exception($"Unknown IProgramUnit type: {programUnitDto.GetType().ToString()}");
////        }
////    }
////}
