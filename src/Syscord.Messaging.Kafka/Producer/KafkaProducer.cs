using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Syscord.Messaging.Kafka.Producer;

public sealed class KafkaProducer<TKey, TMessage>(
    KafkaProducerConfiguration producerConfiguration,
    ISerializer<TKey> keySerializer,
    ISerializer<TMessage> messageSerializer)
    : IKafkaProducer<TKey, TMessage>
{
    private readonly IProducer<TKey, TMessage> producer =
        new ProducerBuilder<TKey, TMessage>(producerConfiguration.ProducerConfig)
            .SetKeySerializer(keySerializer)
            .SetValueSerializer(messageSerializer)
            .Build();

    private readonly string topic = producerConfiguration.Topic;

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