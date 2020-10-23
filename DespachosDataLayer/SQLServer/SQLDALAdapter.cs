using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDataLayer.SQLServer
{
    public abstract class SQLDALAdapter : SQLImplementation
    {
        protected override sealed IDataBaseSQLConnect GetDataBaseHelper()
        {
            return DataBaseSQLConnect.GetInstace();
        }
    }
}
