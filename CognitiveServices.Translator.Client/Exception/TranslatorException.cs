using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace CognitiveServices.Translator
{
    public abstract class TranslatorException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorException"/> class.
        /// </summary>
        public TranslatorException() : base() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TranslatorException(string message): base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public TranslatorException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected TranslatorException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public TranslatorError Error { get; private set; }

        /// <summary>
        /// Parses the response error.
        /// </summary>
        /// <param name="response">The response.</param>
        internal void ParseResponseError(HttpResponseMessage response)
        {
            var responseBody = response.Content.ReadAsStringAsync().Result;

            try
            {
                var result = JsonConvert.DeserializeObject<TranslatorErrorResponse>(responseBody);
                Error = result.Error;
            }
            catch (JsonException)
            {
                // Unable to read the official error.
            }
        }
    }
}
