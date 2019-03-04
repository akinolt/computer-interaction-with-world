using Microsoft.AspNetCore.Mvc;
using WebApi.Interface.Speech.Dtos;
using WebApi.Speech;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SpeechController : Controller
    {
        private readonly IPhraseQueue phraseQueue;

        public SpeechController(IPhraseQueue phraseQueue)
        {
            this.phraseQueue = phraseQueue;
        }

        // POST api/phrases/queue
        [Route("queue")]
        [HttpPut]
        public void Push([FromBody]PhraseToSay phraseToSay)
        {
            this.phraseQueue.Enqueue(phraseToSay);
        }

        // POST api/phrases/dequeue
        [Route("dequeue")]
        [HttpPost]
        public IActionResult Dequeue()
        {
            if (this.phraseQueue.TryDequeue(out var phraseToSay))
            {
                return Ok(phraseToSay);
            }

            return NotFound();
        }
    }
}
