using Confluent.Kafka;
using NUnit.Framework;
using Syscord.Messaging.Kafka.Producer;
using Syscord.Messaging.Kafka.Serializers;
using Syscord.Users.Service.Services.Events;

namespace StressTests;

public class SomeTests
{
    [Test]
    public async Task Test()
    {
        var kafkaProducer = new KafkaProducer<Guid, UserCreatedEvent>(new KafkaProducerConfiguration("users-update",
                new ProducerConfig
                {
                    BootstrapServers = "localhost:9092",
                }),
            KafkaGuidSerializer.Instance,
            KafkaJsonSerializer<UserCreatedEvent>.Instance);

        for (int i = 0; i < 10; i++)
        {
            var userCreatedEvent = new UserCreatedEvent
            {
                Id = Guid.NewGuid(),
                Requisites = new Dictionary<string, string>
                {
                    { "base/login", Guid.NewGuid().ToString() }
                }
            };
            await kafkaProducer.ProduceAsync(userCreatedEvent.Id, userCreatedEvent, default);
        }
    }
}