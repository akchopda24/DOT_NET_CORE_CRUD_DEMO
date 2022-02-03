using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDDemo.Entities.GenericResponse
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
