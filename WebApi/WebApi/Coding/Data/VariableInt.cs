namespace WebApi.Coding.Data
{
    public class VariableInt : IntData
    {
        private int value;

        public override int Value => this.value;

        public void SetValue(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
