using WebApi.Interface.Coding.Dtos.Data;

namespace WebApi.Interface.Coding.Dtos.Actions
{
    public class SayPhraseAction : IAction
    {
        public IData PhraseToSay { get; set; }
    }
}
