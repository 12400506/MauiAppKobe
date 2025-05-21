using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Framework
{
    public abstract class SqlServer
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        public SqlServer()
        {
            connection = new SqlConnection(Settings.GetConnectionString());
        }

        protected SelectResult Select(SqlCommand selectCommand)
        {
            var result = new SelectResult();
            try
            {
                using (connection)
                {
                    selectCommand.Connection = connection;
                    connection.Open();
                    adapter = new SqlDataAdapter(selectCommand);
                    result.DataTable = new System.Data.DataTable();
                    adapter.Fill(result.DataTable);
                    connection.Close();
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        protected SelectResult Select(string tableName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"SELECT * FROM {tableName}";
            return Select(command);
        }

        protected InsertResult Insert(SqlCommand insertCommand)
        {
            InsertResult insertResult = new InsertResult();
            try
            {
                using (connection)
                {
                    insertCommand.CommandText += "SET @new_id = SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction =
                    ParameterDirection.Output;
                    insertCommand.Connection = connection;
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                    insertResult.NewId = newId;
                    connection.Close();
                }
                insertResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                insertResult.AddError(ex.Message);
            }
            return insertResult;
        }
        protected InsertResult InsertRecord(SqlCommand insertCommand)
        {
            InsertResult result = new InsertResult();
            try
            {
                using (connection)
                {
                    connection.Open();
                    insertCommand.Connection = connection;
                    insertCommand.ExecuteNonQuery();
                    result.Succeeded = true;
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
        protected UpdateResult ExecuteUpdate(SqlCommand updateCommand)
        {
            var result = new UpdateResult();
            try
            {
                using (connection = new SqlConnection(Settings.GetConnectionString()))
                {
                    updateCommand.Connection = connection;
                    connection.Open();
                    result.RowsAffected = updateCommand.ExecuteNonQuery();
                    connection.Close();
                    result.Succeeded = true;
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
