using WebApi.Coding.Domain.Data;
using WebApi.Speech;

namespace WebApi.Coding.Domain.Actions
{
    public class SayPhraseAction : IAction
    {
        public readonly IPhraseQueue phraseQueue;

        public SayPhraseAction(IData phraseToSay, IPhraseQueue phraseQueue)
        {
            this.PhraseToSay = phraseToSay;

            this.phraseQueue = phraseQueue;
        }

        public IData PhraseToSay { get; }

        public void Act()
        {
            var phraseToSayDto = new Interface.Speech.Dtos.PhraseToSay
            {
                Phrase = this.PhraseToSay.ToString(),
                Language = "en-GB",
                Gender = new Interface.Speech.Enums.Gender { Value = Interface.Speech.Enums.Gender.Female }
            };

            this.phraseQueue.Enqueue(phraseToSayDto);
        }
    }
}
