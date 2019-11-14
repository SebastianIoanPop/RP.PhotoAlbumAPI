using System;
using System.Net;
using System.Runtime.Serialization;

namespace RP.PhotoAlbum.Provider.Feature.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode ResponseStatusCode { get; set; }

        public string ResponseContent { get; set; }

        public string RequestUri { get; set; }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpResponseException(string message) : this(message, null)
        {
        }

        public HttpResponseException(string message, Exception inner) : base(message, inner)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}\r\n" +
                   $"-->ResponseStatus: {ResponseStatusCode}, " +
                   $"RequestUri: {RequestUri}, Content: [{ResponseContent}]";
        }
    }
}
