using System.Collections.Generic;
using System.Linq;
using WebApi.Coding.Domain.Actions;

namespace WebApi.Coding.Domain
{
    public class Program
    {
        public Program(string programName, IEnumerable<IAction> actions)
        {
            this.ProgramName = programName;

            this.ActionList = actions.ToList();
        }

        public string ProgramName { get; }

        public List<IAction> ActionList { get; }
    }
}
