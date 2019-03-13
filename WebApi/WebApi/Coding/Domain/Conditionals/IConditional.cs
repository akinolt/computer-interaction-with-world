using System.Collections.Generic;
using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Domain.Conditionals
{
    public interface IConditional
    {
        bool Evaluate();
    }
}
