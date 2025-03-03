using System.Threading;
using System.Threading.Tasks;

namespace Syscord.Messaging.Kafka;

public interface IKafkaProducer<TKey, TMessage>
{
    Task ProduceAsync(TKey key, TMessage message, CancellationToken token);
}