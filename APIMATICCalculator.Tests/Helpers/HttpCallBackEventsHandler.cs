using APIMATICCalculator.Standard.Http.Client;
using APIMATICCalculator.Standard.Http.Request;
using APIMATICCalculator.Standard.Http.Response;

namespace APIMATICCalculator.Tests.Helpers
{
    public class HttpCallBackEventsHandler
    {
        public HttpRequest Request { get; private set; }

        public HttpResponse Response { get; private set; }

        public void OnBeforeHttpRequestEventHandler(IHttpClient source, HttpRequest request)
        {
            this.Request = request;
        }

        public void OnAfterHttpResponseEventHandler(IHttpClient source, HttpResponse response)
        {
            this.Response = response;
        }
    }
}
