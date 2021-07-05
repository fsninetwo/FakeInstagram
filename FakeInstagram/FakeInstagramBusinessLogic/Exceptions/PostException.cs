using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Exceptions
{
    public class PostException : NullReferenceException
    {
        public PostException(string message) : base(message)
        {

        }
    }
}
