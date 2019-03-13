namespace WebApi.Coding.Domain.Data
{
    public class VariableString : StringData, IVariable
    {
        private string value;

        public VariableString(string name)
        {
            this.Name = name;
        }

        public VariableString(string name, string value)
        {
            this.Name = name;
            this.value = value;
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
