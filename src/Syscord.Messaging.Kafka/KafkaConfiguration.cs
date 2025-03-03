using Confluent.Kafka;

namespace Syscord.Messaging.Kafka;

public sealed record KafkaConfiguration(string Topic, ProducerConfig ProducerConfig);