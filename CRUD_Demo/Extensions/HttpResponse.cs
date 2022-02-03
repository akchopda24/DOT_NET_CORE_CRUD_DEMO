using CRUDDemo.Entities.GenericResponse;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDemoWebAPI.Extensions
{
    public static class HttpResponse
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.HttpCode
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.HttpCode
            };
        }
    }
}
