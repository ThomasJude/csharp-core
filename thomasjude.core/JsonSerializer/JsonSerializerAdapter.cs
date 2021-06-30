
using JsonSerial = System.Text.Json.JsonSerializer;

namespace ThomasJude.Core.JsonSerializer
{
    public class JsonSerializerAdapter : IJsonSerializer
    {
        public string Serialize<TIn>(TIn src) => JsonSerial.Serialize<TIn>(src);
        public TOut Deserialize<TOut>(string src) => JsonSerial.Deserialize<TOut>(src);
    }    
}