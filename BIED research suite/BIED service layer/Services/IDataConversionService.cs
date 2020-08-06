using System;
using System.Collections.Generic;
using System.Text;

namespace BIED_service_layer.Services
{
    interface IDataConversionService
    {
        string ConvertJSONtoCSV(string JSON, char csvSeparator);
        string ConvertCSVtoJSON(string CSV, char csvSeparator);
    }
}
