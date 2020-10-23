using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDataLayer.SQLServer
{
    public abstract class SQLImplementation
    {
        protected abstract IDataBaseSQLConnect GetDataBaseHelper();
    }
}