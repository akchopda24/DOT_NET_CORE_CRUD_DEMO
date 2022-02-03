using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDDemo.Entities.GenericResponse
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
