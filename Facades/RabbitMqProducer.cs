﻿using RabbitMQ.Client;
using SaudeIA.Facades.Interfaces;
using System.Text;
using System.Text.Json;

public class RabbitMQProducer : IRabbitMqProducer
{
  private readonly ConnectionFactory _factory;
  private readonly string _queueName;

  public RabbitMQProducer(string hostname, string queueName)
  {
    _factory = new ConnectionFactory() { HostName = hostname };
    _queueName = queueName;
  }

  public async void SendMessage<MessageEvent>(MessageEvent message)
  {
    using var connection = await _factory.CreateConnectionAsync();
    using var channel = await connection.CreateChannelAsync(); 

    await channel.QueueDeclareAsync(
        queue: _queueName,
        durable: true,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    var json = JsonSerializer.Serialize(message);
    var body = Encoding.UTF8.GetBytes(json);

    var properties = new BasicProperties
    {
      Persistent = true
    };

    await channel.BasicPublishAsync(
        exchange: "",
        routingKey: _queueName,
        mandatory: false,
        basicProperties: properties,
        body: body);
  }
}
