using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Variant_2.Task3;
#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
//using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Runtime.CompilerServices;
#endregion
namespace Variant_2
{
    public class Task4
    {
        public interface ICreator
        {
            object Create();
        }
        public interface IDataSerializer
        {
            void Serialize<T>(T data, Stream stream);
        }
        public class DataSerializer
        {
            public void Serialize<T>(T data, Stream stream)
            {
                using (var writer = new Utf8JsonWriter(stream))
                {
                    JsonSerializer.Serialize(writer, data);
                }
            }
            public T Deserealize<T>(Stream stream)
            {
                return
                    JsonSerializer.Deserialize<T>(stream);
            }
        }
        public class Task4
        {
            private readonly Grep grep;
            private readonly DataSerializer serializer;
        }
    }
}