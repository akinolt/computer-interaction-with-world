using System.Collections.Generic;
using System.Linq;

namespace WebApi.Coding.Domain.Actions
{
    public class ActionList : IAction
    {
        public ActionList(IEnumerable<IAction> actions)
        {
            this.Actions = actions.ToList();
        }

        public List<IAction> Actions { get; }

        public void Act()
        {
            foreach (var action in this.Actions)
            {
                action.Act();
            }
        }
    }
}
