using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Aplicacion.ManejadorError
{
    public class JsonException : Exception
    {
        public string JsonMessage { get; }

        public JsonException(string message) : base(message)
        {
            JsonMessage = JsonSerializer.Serialize(new { ok = false, message });
        }
    }
}