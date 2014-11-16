using Newtonsoft.Json;

namespace Church.Common.Internal
{
    /// <summary>
    /// Provides methods for serializing and de-serializing objects.
    /// </summary>
    public sealed class NewtonsoftObjectSerializer : IObjectSerializer
    {
        /// <summary>
        /// Serializes the specified object to a string.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A string representation of the object.</returns>
        public string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Deserializes the specified text to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The text to deserialize.</typeparam>
        /// <param name="text">The type of the object to deserialize to.</param>
        /// <returns>The deserialized object from the text.</returns>
        public T DeserializeObject<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}
