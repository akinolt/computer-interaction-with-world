using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Domain.Conditionals
{
    public class Equals : IConditional
    {
        public Equals(IData value1, IData value2)
        {
            this.Value1 = value1;
            this.Value2 = value2;
        }

        public IData Value1 { get; }

        public IData Value2 { get; }

        public bool Evaluate()
        {
            return this.Value1.Equals(this.Value2);
        }
    }
}
