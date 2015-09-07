using System;
using System.Runtime.Serialization;

namespace SharpFont
{
    /// <summary>
    /// Represents errors that occur due to invalid data in a font file.
    /// </summary>
    [Serializable]
    public class InvalidFontException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFontException"/> class.
        /// </summary>
        public InvalidFontException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFontException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidFontException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFontException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidFontException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidFontException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected InvalidFontException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
