using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CRUDDemo.Entities.GenericResponse
{
    public interface IResponse
    {
        string StatusCode { get; set; }
        HttpStatusCode HttpCode { get; set; }
        bool IsError { get; set; }
        string Message { get; set; }
    }
}
