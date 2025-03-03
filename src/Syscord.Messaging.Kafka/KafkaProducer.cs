using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Syscord.Messaging.Kafka;

public sealed class KafkaProducer<TKey, TMessage>(
    KafkaConfiguration configuration,
    ISerializer<TKey> keySerializer,
    ISerializer<TMessage> messageSerializer)
    : IKafkaProducer<TKey, TMessage>
{
    private readonly IProducer<TKey, TMessage> producer =
        new ProducerBuilder<TKey, TMessage>(configuration.ProducerConfig)
            .SetKeySerializer(keySerializer)
            .SetValueSerializer(messageSerializer)
            .Build();

    private readonly string topic = configuration.Topic;

    public async Task ProduceAsync(TKey key, TMessage message, CancellationToken token)
    {
        await producer.ProduceAsync(
            topic,
            new Message<TKey, TMessage>
            {
                Key = key,
                Value = message,
            }, token);
    }
}