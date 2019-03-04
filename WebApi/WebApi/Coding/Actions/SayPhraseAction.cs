using WebApi.Coding.Data;
using WebApi.Speech;

namespace WebApi.Coding.Actions
{
    public class SayPhraseAction : IAction
    {
        public readonly IData phraseToSay;

        public readonly IPhraseQueue phraseQueue;

        public SayPhraseAction(IData phraseToSay, IPhraseQueue phraseQueue)
        {
            this.phraseToSay = phraseToSay;

            this.phraseQueue = phraseQueue;
        }

        public void Act()
        {
            var phraseToSayDto = new Interface.Speech.Dtos.PhraseToSay
            {
                Phrase = this.phraseToSay.ToString(),
                Language = "en-GB",
                Gender = new Interface.Speech.Enums.Gender { Value = Interface.Speech.Enums.Gender.Female }
            };

            this.phraseQueue.Enqueue(phraseToSayDto);
        }
    }
}
