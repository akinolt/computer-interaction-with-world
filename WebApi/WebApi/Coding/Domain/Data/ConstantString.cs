namespace WebApi.Coding.Domain.Data
{
    public class ConstantString : StringData
    {
        public ConstantString(string value)
        {
            this.Value = value;
        }

        public override string Value { get; }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
