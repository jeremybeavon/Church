using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;

namespace Church.Web.Identity
{
    /// <summary>
    /// Provides an exception for when a claim is not found.
    /// </summary>
    [Serializable]
    public sealed class ClaimNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimNotFoundException"/> class.
        /// </summary>
        public ClaimNotFoundException() 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ClaimNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public ClaimNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimNotFoundException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized
        /// object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual
        /// information about the source or destination.</param>
        private ClaimNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) 
        {
        }
    }
}