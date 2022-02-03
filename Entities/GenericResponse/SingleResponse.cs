using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CRUDDemo.Entities.GenericResponse
{
    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : new()
    {
        public SingleResponse()
        {
            Model = new TModel();
        }
        public string StatusCode { get; set; }
        public HttpStatusCode HttpCode { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public TModel Model { get; set; }
    }
}
