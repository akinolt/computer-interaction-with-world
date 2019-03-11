namespace WebApi.Coding.Domain.Data
{
    public class ConstantInt : IntData
    {
        public ConstantInt(int value)
        {
            this.Value = value;
        }

        public override int Value { get; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
