using System.Text;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace Syscord.Messaging.Kafka.Serializers;

public sealed class KafkaJsonSerializer<T> : ISerializer<T>
{
    public static readonly ISerializer<T> Instance = new KafkaJsonSerializer<T>();
    
    public byte[] Serialize(T data, SerializationContext context)
        => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
}