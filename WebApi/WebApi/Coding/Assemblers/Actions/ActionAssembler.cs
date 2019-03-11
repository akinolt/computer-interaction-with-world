using System;
using WebApi.Coding.Domain.Actions;

namespace WebApi.Coding.Assemblers.Actions
{
    public interface IActionAssembler
    {
        Interface.Coding.Dtos.Actions.IAction Assemble(IAction action);

        IAction Disassemble(Interface.Coding.Dtos.Actions.IAction actionDto);
    }

    public class ActionAssembler : IActionAssembler
    {
        private readonly ISayPhraseActionAssembler sayPhraseActionAssembler;

        public ActionAssembler(ISayPhraseActionAssembler sayPhraseActionAssembler)
        {
            this.sayPhraseActionAssembler = sayPhraseActionAssembler;
        }

        public Interface.Coding.Dtos.Actions.IAction Assemble(IAction action)
        {
            var sayPhraseAction = action as Domain.Actions.SayPhraseAction;
            if (sayPhraseAction != null)
            {
                return this.sayPhraseActionAssembler.Assemble(sayPhraseAction);
            }

            // None of the IAction types matches. We failed to disassmble.
            throw new Exception($"Unknown IAction type: {action.GetType().ToString()}");
        }

        public IAction Disassemble(Interface.Coding.Dtos.Actions.IAction actionDto)
        {
            var sayPhraseActionDto = actionDto as Interface.Coding.Dtos.Actions.SayPhraseAction;
            if (sayPhraseActionDto != null)
            {
                return this.sayPhraseActionAssembler.Disassemble(sayPhraseActionDto);
            }

            // None of the IAction types matches. We failed to disassmble.
            throw new Exception($"Unknown IAction type: {actionDto.GetType().ToString()}");
        }
    }
}
