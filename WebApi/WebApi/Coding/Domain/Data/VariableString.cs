namespace WebApi.Coding.Domain.Data
{
    public class VariableString : StringData
    {
        private string value;

        public VariableString(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

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
