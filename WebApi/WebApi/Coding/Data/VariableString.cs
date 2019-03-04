namespace WebApi.Coding.Data
{
    public class VariableString : StringData
    {
        private string value;

        public override string Value => this.value;

        public void SetValue(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
