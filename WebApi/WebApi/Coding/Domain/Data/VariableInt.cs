using System;

namespace WebApi.Coding.Domain.Data
{
    public class VariableInt : IntData, IVariable
    {
        private int value;

        public VariableInt(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

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
