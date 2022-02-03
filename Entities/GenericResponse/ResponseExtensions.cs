using CRUDDemo.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CRUDDemo.Entities.GenericResponse
{
    public static class ResponseExtensions
    {
        public static void SetError(this IResponse response, Exception ex)
        {
            response.IsError = true;
            var cast = ex as ApplicationException;
            response.HttpCode = System.Net.HttpStatusCode.InternalServerError;
            response.StatusCode = StatusCode.INTERNAL_SERVER_ERROR_500;
            if (cast == null)
            {
                response.Message = HttpResponseMessages.INTERNAL_SERVER_ERROR;
            }
            else
            {
                response.Message = ex.Message;
            }
        }

        public static void SetResponse(this IResponse response, bool isError, string statusCode, string message, HttpStatusCode httpCode)
        {
            response.IsError = isError;
            response.HttpCode = httpCode;
            response.StatusCode = statusCode;
            response.Message = message;
        }

    }
}
