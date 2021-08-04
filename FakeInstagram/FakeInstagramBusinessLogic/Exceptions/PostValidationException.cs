using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Exceptions
{
    public class PostValidationException : Exception
    {
        public PostValidationException(string message) : base(message)
        {

        }
    }
}
