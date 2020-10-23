using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DespachosDataLayer.SQLServer
{
    public class DataBaseSQLConnect : IDataBaseSQLConnect
    {
        public static readonly string connectionString;
        private static readonly object syncRoot;
        private static DataBaseSQLConnect instance;

        static DataBaseSQLConnect()
        {
            syncRoot = new object();
            connectionString = GetConectionString(Settings.Default.DataSourceSQL, Settings.Default.DataBaseNameSQL, Settings.Default.UserIDSQL, Settings.Default.PasswordSQL, Settings.Default.TimeOutConnectionSQL);
            instance = null;
        }

        private DataBaseSQLConnect() { }

        public static DataBaseSQLConnect GetInstace()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new DataBaseSQLConnect();
                    }
                }
            }
            return instance;
        }

        private static string GetConectionString(string dataSource, string dataBaseName, string userId, string password, int timeOut)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = dataSource.Trim();
            builder.InitialCatalog = dataBaseName.Trim();
            builder.UserID = userId.Trim();
            builder.Password = password.Trim();
            //builder.AsynchronousProcessing = true;
            builder.ConnectTimeout = timeOut;
            return builder.ConnectionString;
        }

        public void ExecuteBulkInsert(string destinationTableName, DataTable data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = destinationTableName;
                    try
                    {
                        bulkCopy.WriteToServer(data);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("The method ExecuteBulkInsert  can not be executed", ex);
                    }
                    finally
                    {
                        bulkCopy.Close();
                    }
                }
            }
        }

        public void ExecuteNonQuery(string sentenceSql, IList<SqlParameter> parameters)
        {
            SqlCommand command = null;
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    command = PrepareCommand(sentenceSql, parameters, connection);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The sentence {0} can not be executed", sentenceSql), ex);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }
        }

        private SqlCommand PrepareCommand(string sentenceSql, IList<SqlParameter> parameters, SqlConnection connection)
        {

            using (SqlCommand command = new SqlCommand(sentenceSql, connection))
            {
                command.CommandTimeout = 600;

                if (parameters.Count > 0)
                {
                    foreach (SqlParameter par in parameters)
                    {
                        command.Parameters.Add(par);
                    }
                }

                return command;
            }
        }

        public void ExecuteProcedureNonQuery(string procedureName, IList<SqlParameter> parameters)
        {
            SqlCommand command = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    command = PrepareCommandProcedure(procedureName, parameters, connection);

                    if (command.Connection.State == ConnectionState.Closed)
                        command.Connection.Open();

                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The procedure {0} can not be executed", procedureName), ex);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }
        }

        private SqlCommand PrepareCommandProcedure(string procedureName, IList<SqlParameter> parameters, SqlConnection connection)
        {

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = procedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.CommandTimeout = 600;
                command.Parameters.Clear();//SAR-236

                for (int i = 0; i < parameters.Count; i++)
                {
                    command.Parameters.Add(parameters[i]);
                }

                return command;
            }
        }

        public SqlParameterCollection ExecuteProcedureOutputParams(string procedureName, IList<SqlParameter> parameters)
        {
            SqlCommand command = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string result = string.Empty;

                    DataSet ResultsDataSet = new DataSet();
                    ResultsDataSet.Locale = CultureInfo.InvariantCulture;

                    command = PrepareCommandProcedure(procedureName, parameters, connection);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.ExecuteNonQuery();

                    return command.Parameters;

                }

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The procedure {0} can not be executed", procedureName), ex);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }
        }

        public string ExecuteProcedureScalar(string procedureName, IList<SqlParameter> parameters)
        {
            SqlCommand command = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    object result = new object();

                    DataSet ResultsDataSet = new DataSet();
                    ResultsDataSet.Locale = CultureInfo.InvariantCulture;

                    command = PrepareCommandProcedure(procedureName, parameters, connection);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Object reference not set to an instance of an object."))
                {
                    throw new Exception(String.Format("The procedure {0} can not be executed", procedureName), ex);
                }
                return null;
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }
        }

        public string ExecuteProcedureScalar1(string procedureName, IList<SqlParameter> parameters)
        {
            SqlCommand command = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string result = string.Empty;
                    command = new SqlCommand();
                    Object returnValue;
                    command.CommandText = procedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        command.Parameters.Add(parameters[i]);
                    }

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    returnValue = command.ExecuteScalar();
                    result = returnValue != null ? returnValue.ToString() : "0";

                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The procedure {0} can not be executed", procedureName), ex);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }
        }

        public DataSet ExecuteProcedureToDataSet(string procedureName)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter DBAdapter = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    DataSet ResultsDataSet = new DataSet();
                    ResultsDataSet.Locale = CultureInfo.InvariantCulture;
                    command.CommandText = procedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = new SqlConnection(connectionString);
                    command.CommandTimeout = 60;
                    DBAdapter = new SqlDataAdapter(command);
                    DBAdapter.Fill(ResultsDataSet);
                    return ResultsDataSet;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The procedure {0} can not be executed", procedureName), ex);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (DBAdapter != null)
                {
                    DBAdapter.Dispose();
                    DBAdapter = null;
                }
            }
        }

        public DataSet ExecuteProcedureToDataSet(string procedureName, IList<SqlParameter> parameters)
        {
            SqlCommand command = null;
            SqlDataAdapter dbAdapter = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    DataSet ResultsDataSet = new DataSet();
                    ResultsDataSet.Locale = CultureInfo.InvariantCulture;
                    command = PrepareCommandProcedure(procedureName, parameters, connection);
                    dbAdapter = new SqlDataAdapter(command);
                    dbAdapter.Fill(ResultsDataSet);
                    return ResultsDataSet;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The procedure {0} can not be executed", procedureName), ex);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }
            }
        }

        public DataSet ExecuteQuery(string sentenceSql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                DataSet ResultsDataSet = new DataSet();
                ResultsDataSet.Locale = CultureInfo.InvariantCulture;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter.SelectCommand = new SqlCommand(sentenceSql, connection);
                    adapter.Fill(ResultsDataSet);
                    return ResultsDataSet;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The sentence {0} can not be executed", sentenceSql), ex);
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                    adapter = null;
                }
            }
        }

        public DataSet ExecuteQuery(string sentenceSql, IList<SqlParameter> parameters, bool useManagerUsers)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                DataSet ResultsDataSet = new DataSet();
                ResultsDataSet.Locale = CultureInfo.InvariantCulture;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    adapter.SelectCommand = PrepareCommand(sentenceSql, parameters, conn);
                    adapter.Fill(ResultsDataSet);
                }
                return ResultsDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The sentence {0} can not be executed", sentenceSql), ex);
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                    adapter = null;
                }
            }
        }

        public DataSet ExecuteQuery(string sentenceSql, IList<SqlParameter> parameters)
        {
            return ExecuteQuery(sentenceSql, parameters, false);
        }

        public string ExecuteScalar(string sentenceSql, IList<SqlParameter> parameters)
        {
            SqlCommand command = null;
            try
            {
                string result = string.Empty;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    command = PrepareCommand(sentenceSql, parameters, connection);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    result = command.ExecuteScalar().ToString();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("The sentence {0} can not be executed", sentenceSql), ex);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }
        }

        public bool SqlDbValueToBool(object obj)
        {
            return obj != DBNull.Value;
        }

        public int SqlDbValueToInt(object obj)
        {
            return obj != DBNull.Value ? Convert.ToInt16(obj) : 0;
        }

        public long SqlDbValueToLong(object obj)
        {
            return obj != DBNull.Value ? Convert.ToInt64(obj) : 0;
        }

        public string SqlDbValueToString(object obj)
        {
            return obj != DBNull.Value ? obj.ToString() : string.Empty;
        }
    }
}