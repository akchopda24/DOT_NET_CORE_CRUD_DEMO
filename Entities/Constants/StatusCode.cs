using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDDemo.Entities.Constants
{
    public static class StatusCode
    {
        public const string NO_DATA_FOUND_200 = "NDF_200";
        public const string DATA_FOUND_200 = "DF_200";
        public const string DATA_ADD_SUCCESS_200 = "DAS_200";
        public const string DATA_UPDATE_SUCCESS_200 = "DUS_200";
        public const string DATA_DELETE_SUCCESS_200 = "DDS_200";
        public const string DATA_IS_IN_USE_200 = "DIIU_200";
        public const string INTERNAL_SERVER_ERROR_500 = "ISE_500";
        public const string BAD_REQUEST_400 = "BR_400";
    }
}
