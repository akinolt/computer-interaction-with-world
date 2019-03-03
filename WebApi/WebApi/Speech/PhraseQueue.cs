using WebApi.Interface.Dtos;
using System.Collections.Concurrent;

namespace WebApi.Speech
{
    public interface IPhraseQueue
    {
        void Enqueue(PhraseToSay phraseToSay);

        bool TryDequeue(out PhraseToSay phraseToSay);
    }

    public class PhraseQueue : ConcurrentQueue<PhraseToSay>, IPhraseQueue
    {
    }
}
