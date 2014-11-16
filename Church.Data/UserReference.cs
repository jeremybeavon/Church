using Church.Common;

namespace Church.Data
{
    /// <summary>
    /// Represents a participant in a conversation.
    /// </summary>
    public sealed class UserReference : AbstractData
    {
        /// <summary>
        /// Gets or sets the name of this participant.
        /// </summary>
        public string Name { get; set; }
    }
}
