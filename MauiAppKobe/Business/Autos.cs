using ClassLibrary1;
using ClassLibrary1.Data.Framework;
using MauiAppKobe.Data;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public static class Cars
    {
        public static InsertResult Add(Car car)
        {
            
            CarData carData = new CarData();
            InsertResult result = carData.Insert(car);
            return result;
        }
    }
}
