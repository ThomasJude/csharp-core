
using System;

namespace thomasjude.core.Serialization
{
    public interface ISerializer
    {
        string Serialize<TIn>(TIn src);
        TOut Deserialize<TOut>(string src);
    }
}