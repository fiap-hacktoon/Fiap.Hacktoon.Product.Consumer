using System.Text.Json.Serialization;

namespace Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;

public class Identifier
{
    [JsonPropertyName("id")]
    public Guid? Id { get; set; }

    public Identifier() { }
}