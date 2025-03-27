using System.Net;

namespace InkHouse.Exceptions;

public class HttpException(string message, HttpStatusCode statusCode) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}