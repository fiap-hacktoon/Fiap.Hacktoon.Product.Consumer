using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects
{
    public class Identifier
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        public Identifier() { }
    }
}