using System;
using System.Buffers;
using System.Text.Json;

namespace IdentityServer4.Extensions
{
    public static class JsonExtentions
    {
        //public static T ToObject<T>(this JsonDocument document)
        //{
        //    var json = document.RootElement.GetRawText();
        //    return JsonSerializer.Deserialize<T>(json);
        //}

        //public static T ToObject<T>(this JsonElement element)
        //{
        //    var json = element.GetRawText();
        //    return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions() { IncludeFields = true });
        //}
        public static T ToObject<T>(this JsonElement element, JsonSerializerOptions options = null)
        {
            var bufferWriter = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
                element.WriteTo(writer);
            return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
        }
    }
}