using ClassLibrary1.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppKobe.Data
{
    internal class CarData : SqlServer
    {
        public CarData()
        {
            TableName = "Cars";
        }

        public string TableName { get; set; }

        public SelectResult Select()
        {
            return base.Select(TableName);
        }

        public InsertResult Insert(Car car)
        {
            var result = new InsertResult();
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"INSERT INTO {TableName} ");
                insertQuery.Append($"(CarId, CarBrand, CarYear, CarPrice, CarEngineSize) VALUES ");
                insertQuery.Append($"(@CarId, @CarBrand, @CarYear, @CarPrice, @CarEngineSize); ");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@CarId", SqlDbType.NVarChar).Value = car.Id;
                    insertCommand.Parameters.Add("@CarBrand", SqlDbType.Decimal).Value = car.CarBrand;
                    insertCommand.Parameters.Add("@CarYear", SqlDbType.Int).Value = car.CarYear;
                    insertCommand.Parameters.Add("@CarPrice", SqlDbType.NVarChar).Value = car.CarPrice;
                    insertCommand.Parameters.Add("@CarEngineSize", SqlDbType.NVarChar).Value = car.CarEngineSize;

                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
