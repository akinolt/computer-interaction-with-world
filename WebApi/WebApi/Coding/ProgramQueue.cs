using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using WebApi.Coding.Domain.Actions;
using WebApi.Coding.Domain.Data;

namespace WebApi.Coding
{
    public interface IProgramQueue : IEnumerable<Domain.Program>
    {
        Domain.Program CurrentProgram { get; }

        void Enqueue(Domain.Program program);

        void MoveToNextProgramInQueue();
    }

    public class ProgramQueue : ConcurrentQueue<Domain.Program>, IProgramQueue
    {
        public ProgramQueue(Func<IData, SayPhraseAction> sayPhraseActionFactory)
        {
            var actions = new[] { (IAction)sayPhraseActionFactory(new ConstantString("Fish pie")), sayPhraseActionFactory(new VariableInt("Fish")) }.ToList();

            var program = new Domain.Program("Test Program", actions);

            this.Enqueue(program);
        }

        public Domain.Program CurrentProgram { get; private set; }

        public void MoveToNextProgramInQueue()
        {
            if (!this.TryDequeue(out var program))
            {
                this.CurrentProgram = null;
                return;
            }

            this.CurrentProgram = program;
        }
    }
}
