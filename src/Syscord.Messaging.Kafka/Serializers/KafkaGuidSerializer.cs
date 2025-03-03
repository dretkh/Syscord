using System;
using Confluent.Kafka;

namespace Syscord.Messaging.Kafka.Serializers;

public sealed class KafkaGuidSerializer : ISerializer<Guid>
{
    public static readonly KafkaGuidSerializer Instance = new();
    
    public byte[] Serialize(Guid data, SerializationContext context) => data.ToByteArray(bigEndian: false);
}