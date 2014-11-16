namespace Church.Common
{
    /// <summary>
    /// Provides methods for serializing and de-serializing objects.
    /// </summary>
    public interface IObjectSerializer
    {
        /// <summary>
        /// Serializes the specified object to a string.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A string representation of the object.</returns>
        string SerializeObject<T>(T obj);

        /// <summary>
        /// Deserializes the specified text to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The text to deserialize.</typeparam>
        /// <param name="text">The type of the object to deserialize to.</param>
        /// <returns>The deserialized object from the text.</returns>
        T DeserializeObject<T>(string text);
    }
}
