using ClassLibrary1;
using ClassLibrary1.Data.Framework;
using MauiAppKobe.Data;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public static class Cars
    {

        public static SelectResult GetCars()
        {
            var carData = new CarData();
            return carData.Select();
        }
        public static InsertResult AddCars(Car car)
        {
            
            CarData carData = new CarData();
            InsertResult result = carData.Insert(car);
            return result;
        }
    }
}
