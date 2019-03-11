using System.Collections.Generic;
using WebApi.Interface.Coding.Dtos.Actions;

namespace WebApi.Interface.Coding.Dtos
{
    public class Program
    {
        public Program()
        {
            this.Actions = new List<IAction>();
        }

        public string ProgramName { get; set; }

        public List<IAction> Actions { get; set; }
    }
}