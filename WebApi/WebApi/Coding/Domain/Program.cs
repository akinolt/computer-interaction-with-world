using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Coding.Domain.Actions;
using WebApi.Coding.Domain.Data;

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

        public void RunWithStringParameter(VariableString stringParameter)
        {
            foreach (var action in this.ActionList)
            {
                action.Act();
            }
        }
    }
}
