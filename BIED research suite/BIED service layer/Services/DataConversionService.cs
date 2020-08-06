using System;
using System.Collections.Generic;
using System.Text;

namespace BIED_service_layer.Services
{
    class DataConversionService : IDataConversionService
    {
        string IDataConversionService.ConvertCSVtoJSON(string CSV, char csvSeparator)
        {
            throw new NotImplementedException();
        }

        string IDataConversionService.ConvertJSONtoCSV(string JSON, char csvSeparator)
        {
            throw new NotImplementedException();
        }
    }
}
