using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        public string message;
        public ObjectAlreadyExistsException(string message) : base(message)
        {
            this.message = message;
        }
    }
}
