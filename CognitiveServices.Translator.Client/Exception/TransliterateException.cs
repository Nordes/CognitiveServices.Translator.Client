using System;
using System.Runtime.Serialization;

namespace CognitiveServices.Translator
{
    public class TransliterateException : TranslatorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransliterateException" /> class.
        /// </summary>
        public TransliterateException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransliterateException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public TransliterateException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransliterateException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public TransliterateException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransliterateException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected TransliterateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}