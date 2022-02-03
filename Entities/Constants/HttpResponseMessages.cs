using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDDemo.Entities.Constants
{
    public static class HttpResponseMessages
    {
        public const string NO_DATA_FOUND = "No data found for this request.";
        public const string DATA_FOUND_SUCCESS = "Data found for this request.";
        public const string DATA_ADD_SUCCESS = "Data has been added successfully.";
        public const string DATA_UPDATE_SUCCESS = "Data has been updated successfully";
        public const string DATA_DELETE_SUCCESS = "Data has been deleted successfully.";
        public const string INTERNAL_SERVER_ERROR = "There was an internal error. Please contact to technical support!";
        public const string ID_SHOULD_ZERO = "ID should be zero for new entry!";
        public const string DATA_IS_IN_USE = "Data is in use, can't take any action!";
    }
}
