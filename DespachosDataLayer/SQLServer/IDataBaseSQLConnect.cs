using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DespachosDataLayer.SQLServer
{
    public interface IDataBaseSQLConnect
    {
        DataSet ExecuteQuery(string sentenceSql);

        DataSet ExecuteQuery(string sentenceSql, IList<SqlParameter> parameters, bool useManagerUsers);

        DataSet ExecuteQuery(string sentenceSql, IList<SqlParameter> parameters);

        void ExecuteNonQuery(string sentenceSql, IList<SqlParameter> parameters);

        string ExecuteScalar(string sentenceSql, IList<SqlParameter> parameters);

        DataSet ExecuteProcedureToDataSet(string procedureName);

        DataSet ExecuteProcedureToDataSet(string procedureName, IList<SqlParameter> parameters);

        void ExecuteProcedureNonQuery(string procedureName, IList<SqlParameter> parameters);

        string ExecuteProcedureScalar(string procedureName, IList<SqlParameter> parameters);

        string ExecuteProcedureScalar1(string procedureName, IList<SqlParameter> parameters);

        SqlParameterCollection ExecuteProcedureOutputParams(string procedureName, IList<SqlParameter> parameters);

        void ExecuteBulkInsert(string destinationTableName, DataTable data);

        bool SqlDbValueToBool(object obj);

        string SqlDbValueToString(object obj);

        Int64 SqlDbValueToLong(object obj);

        int SqlDbValueToInt(object obj);
    }
}
