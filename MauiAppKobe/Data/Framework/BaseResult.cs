using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Framework
{
    public abstract class BaseResult
    {

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public void AddError(string error)
        {
            Message = error;
            Succeeded = false;
        }
    }
}
