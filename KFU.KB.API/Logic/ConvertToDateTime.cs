using System;
using System.Buffers;
using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KFU.KB.API.Logic
{
    public class ConvertToDateT
    {
        public class StringToDateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
            {
                if (reader.GetString() == "")
                    return new DateTime();
                return DateTime.Parse(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

        }
    }
}