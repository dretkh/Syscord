using Confluent.Kafka;

namespace Syscord.Messaging.Kafka.Producer;

public sealed record KafkaProducerConfiguration(string Topic, ProducerConfig ProducerConfig);