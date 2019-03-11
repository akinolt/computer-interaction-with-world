using System;

namespace WebApi.Coding.Domain.Data
{
    public abstract class StringData : IData
    {
        public abstract string Value { get; }

        public bool Equals(IData other)
        {
            var otherStringData = other as StringData;
            if (otherStringData == null)
            {
                // Other data is not a string. Evaluate as not equal.
                return false;
            }

            return string.Equals(this.Value, otherStringData.Value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
