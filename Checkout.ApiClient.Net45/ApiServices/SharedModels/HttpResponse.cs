using System.Net;

namespace Checkout.ApiServices.SharedModels
{
    public class HttpResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool HasError { get { return Error != null; } }
        public ResponseError Error { get; set; }
    }

    /// <summary>
    /// Holds the response model
    /// </summary>
    /// <typeparam name="T">generic model returned from the api</typeparam>
    public class HttpResponse<T> : HttpResponse
    {
        public T Model { get; set; }

        public HttpResponse(T model)
        {
            this.Model = model;
        }
    }
}