using System.Linq;
using WebApi.Coding.Assemblers.Actions;
using WebApi.Coding.Domain;
using WebApi.Interface.Coding.Dtos;

namespace WebApi.Coding.Assemblers
{
    public interface IProgramAssembler
    {
        Interface.Coding.Dtos.Program AssembleProgram(Domain.Program program);

        Domain.Program DisassembleProgram(Interface.Coding.Dtos.Program programDto);
    }

    public class ProgramAssembler : IProgramAssembler
    {
        private readonly IActionAssembler actionAssembler;

        public ProgramAssembler(IActionAssembler actionAssembler)
        {
            this.actionAssembler = actionAssembler;
        }

        public Interface.Coding.Dtos.Program AssembleProgram(Domain.Program program)
        {
            var actionDtos = program.ActionList.Select(this.actionAssembler.Assemble).ToList();

            return new Interface.Coding.Dtos.Program
            {
                ProgramName = program.ProgramName,
                Actions = actionDtos
            };
        }

        public Domain.Program DisassembleProgram(Interface.Coding.Dtos.Program programDto)
        {
            var actions = programDto.Actions.Select(this.actionAssembler.Disassemble).ToList();

            return new Domain.Program(programDto.ProgramName, actions);
        }
    }
}
