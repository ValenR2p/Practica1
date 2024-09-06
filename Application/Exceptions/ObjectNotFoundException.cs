using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public string message;
        public ObjectNotFoundException(string message) : base(message) {
            this.message = message;
        }
    }
}
