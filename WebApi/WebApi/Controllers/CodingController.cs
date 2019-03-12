using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Coding;
using WebApi.Coding.Assemblers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CodingController : Controller
    {
        private readonly IProgramQueue programQueue;

        private readonly IProgramAssembler programAssembler;

        public CodingController(IProgramQueue programQueue, IProgramAssembler programAssembler)
        {
            this.programQueue = programQueue;
            this.programAssembler = programAssembler;
        }

        // POST api/programs/queue
        [Route("queue")]
        [HttpGet]
        public IActionResult GetQueue()
        {
            return Ok(this.programQueue.ToList());
        }

        // POST api/programs/queue
        [Route("queue")]
        [HttpPut]
        public void Push([FromBody]Interface.Coding.Dtos.Program programDto)
        {
            var program = this.programAssembler.DisassembleProgram(programDto);

            ////this.programQueue.Enqueue(program);
        }

        // POST api/programs/dequeue
        [Route("dequeue")]
        [HttpPost]
        public IActionResult Dequeue()
        {
            if (this.programQueue.TryDequeue(out var program))
            {
                var programDto = this.programAssembler.AssembleProgram(program);
                return Ok(programDto);
            }

            return NotFound();
        }
    }
}
