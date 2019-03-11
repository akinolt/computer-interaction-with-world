using WebApi.Interface.Coding.Dtos.Data;

namespace WebApi.Interface.Coding.Dtos.Conditionals
{
    public class Equals : IConditional
    {
        public IData Value1 { get; set; }

        public IData Value2 { get; set; }
    }
}
