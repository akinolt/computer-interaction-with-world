using System;
using WebApi.Coding.Assemblers.Data;
using WebApi.Coding.Domain.Actions;
using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Assemblers.Actions
{
    public interface ISayPhraseActionAssembler
    {
        Interface.Coding.Dtos.Actions.SayPhraseAction Assemble(SayPhraseAction sayPhraseAction);

        SayPhraseAction Disassemble(Interface.Coding.Dtos.Actions.SayPhraseAction sayPhraseActionDto);
    }

    public class SayPhraseActionAssembler : ISayPhraseActionAssembler
    {
        private readonly IDataAssembler dataAssembler;

        private readonly Func<IData, SayPhraseAction> sayPhraseActionFactory;

        public SayPhraseActionAssembler(IDataAssembler dataAssembler, Func<IData, SayPhraseAction> sayPhraseActionFactory)
        {
            this.dataAssembler = dataAssembler;
            this.sayPhraseActionFactory = sayPhraseActionFactory;
        }

        public Interface.Coding.Dtos.Actions.SayPhraseAction Assemble(SayPhraseAction sayPhraseAction)
        {
            var phraseToSayDto = this.dataAssembler.Assemble(sayPhraseAction.PhraseToSay);
            return new Interface.Coding.Dtos.Actions.SayPhraseAction { PhraseToSay = phraseToSayDto };
        }

        public SayPhraseAction Disassemble(Interface.Coding.Dtos.Actions.SayPhraseAction sayPhraseActionDto)
        {
            var phraseToSay = this.dataAssembler.Disassemble(sayPhraseActionDto.PhraseToSay);
            return sayPhraseActionFactory(phraseToSay);
        }
    }
}
