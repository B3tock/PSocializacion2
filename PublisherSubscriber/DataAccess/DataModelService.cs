using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Globalization;
using System.Dynamic;

namespace CorePOSApi.Business.Data.context
{
    public class DataModelService
    {
        public readonly SqlConnection _connection;

        public DataModelService()
        {
            _connection = DbContext.CreateConnection();
        }

        public SqlCommand CreateCustomCommand(string CommandText)
        {
            SqlCommand sqlcommand = _connection.CreateCommand();
            sqlcommand.CommandTimeout = 50; //50 seconds Time out 
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.CommandText = CommandText;
            return sqlcommand;
        }

        private object GetNullableValue(SqlDataReader reader, PropertyInfo property)
        {
            var t = property.PropertyType;

            if (reader[property.Name] == null || reader[property.Name] is DBNull)
                return null;

            if (property.PropertyType.Name.Equals(typeof(Nullable<>).Name))
            {
                t = Nullable.GetUnderlyingType(t);
                return Convert.ChangeType(reader[property.Name], t);
            }

            return Convert.ChangeType(reader[property.Name], property.PropertyType);
        }

        public List<TModel> GetListByParameter<TModel, TObject>(string procedure, TObject actualModel)
            where TModel : class, new()
            where TObject : new()
        {
            var responseModel = new List<TModel>();

            using (_connection)
            {
                using (var command = CreateCustomCommand(procedure))
                {
                    CommandSetParameters<TObject>(command, actualModel);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TModel model = new TModel();
                            var properties = model.GetType().GetProperties();

                            foreach (var property in properties)
                            {
                                try
                                {
                                    var obj = GetNullableValue(reader, property);
                                    property.SetValue(model, obj);
                                }
                                catch
                                {

                                }
                            }
                            responseModel.Add(model);
                        }

                    }
                }
            }
            return responseModel;
        }

        public TModel GetObjectByParameter<TModel, TObject>(string procedure, TObject actualModel)
            where TModel : new()
            where TObject : new()
        {
            TModel returnValue = new TModel();
            using (_connection)
            {
                using (var command = CreateCustomCommand(procedure))
                {
                    CommandSetParameters<TObject>(command, actualModel);
                    CommandSetOutPutParameters<TModel>(command, returnValue);
                    int icommand = command.ExecuteNonQuery();

                    var properties = returnValue.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        try
                        {
                            var obj = command.Parameters["@" + property.Name].Value;
                            property.SetValue(returnValue, obj);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return returnValue;
        }

        public int ExecuteNonQueryModel<TObject>(string procedure, TObject actualModel)
            where TObject : new()
        {
            using (_connection)
            {
                using (var command = CreateCustomCommand(procedure))
                {
                    CommandSetParameters<TObject>(command, actualModel);
                    int returnValue = command.ExecuteNonQuery();

                    return returnValue;
                }
            }
        }


        public object ScalarModel<TObject>(string procedure, TObject actualModel)
            where TObject : new()
        {
            using (_connection)
            {
                using (var command = CreateCustomCommand(procedure))
                {
                    CommandSetParameters<TObject>(command, actualModel);
                    return command.ExecuteScalar();
                }
            }
        }

        public void CommandSetParameters<TObject>(SqlCommand command, TObject actualModel)
            where TObject : new()
        {
            var inAttributes = actualModel.GetType().GetProperties();
            foreach (var inAttribute in inAttributes)
            {
                object parameterValue = inAttribute.GetValue(actualModel);
                if (parameterValue == null) parameterValue = DBNull.Value;
                command.Parameters.AddWithValue("@" + inAttribute.Name, parameterValue);
            }
        }

        public void CommandSetOutPutParameters<TObject>(SqlCommand command, TObject actualModel)
            where TObject : new()
        {
            var inAttributes = actualModel.GetType().GetProperties();
            foreach (var inAttribute in inAttributes)
            {
                SqlParameter returnParameter = command.Parameters.AddWithValue("@" + inAttribute.Name, inAttribute.GetValue(actualModel));
                returnParameter.Direction = ParameterDirection.Output;
            }
        }

        public List<dynamic> GetGenericListByParameter<TObject>(string procedure, dynamic actualModel)
        {
            var responseModel = new List<dynamic>();
            using (_connection)
            {
                using (var command = CreateCustomCommand(procedure))
                {
                    var inAttributes = (IDictionary<string, object>)actualModel;
                    foreach (var inAttribute in inAttributes)
                    {
                        object parameterValue = inAttribute.Value;
                        if (parameterValue == null) parameterValue = DBNull.Value;
                        command.Parameters.AddWithValue("@" + inAttribute.Key, parameterValue);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dynamic superItem = new ExpandoObject();
                            IDictionary<string, object> item = superItem;
                            for ( int i = 0; i<reader.FieldCount; i++ )
                            {
                                string property = reader.GetName(i);
                                var obj = reader.GetValue(i);
                                if(obj == null || obj == DBNull.Value)
                                {
                                    obj = string.Empty;
                                }
                                item.Add(property, obj);
                            }
                            responseModel.Add(superItem);
                        }
                    }
                }
            }
            return responseModel;
        }

    }
}