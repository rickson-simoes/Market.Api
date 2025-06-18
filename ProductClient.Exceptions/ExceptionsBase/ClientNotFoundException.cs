using System.Net;

namespace ProductClient.Exceptions.ExceptionsBase
{
    public class ClientNotFoundException(string message) : ProductClientHubException(message)
    {
        public override List<string> GetErrors() => [Message];
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
