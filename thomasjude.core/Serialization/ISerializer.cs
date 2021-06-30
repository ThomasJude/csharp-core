
using System;

namespace ThomasJude.Core.Serialization
{
    public interface ISerializer
    {
        string Serialize<TIn>(TIn src);
        TOut Deserialize<TOut>(string src);
    }
}