namespace WebApi.Coding.Data
{
    public abstract class IntData : IData
    {
        public abstract int Value { get; }

        public bool Equals(IData other)
        {
            var otherIntData = other as IntData;
            if (otherIntData == null)
            {
                // Other data is not a int. Evaluate as not equal.
                return false;
            }

            return this.Value == otherIntData.Value;
        }
    }
}
