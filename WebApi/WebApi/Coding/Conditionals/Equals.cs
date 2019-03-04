using WebApi.Coding.Data;

namespace WebApi.Coding.Conditionals
{
    public class Equals : IConditional
    {
        private readonly IData value1;

        private readonly IData value2;

        public Equals(IData value1, IData value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        public bool Evaluate()
        {
            return value1.Equals(value2);
        }
    }
}
