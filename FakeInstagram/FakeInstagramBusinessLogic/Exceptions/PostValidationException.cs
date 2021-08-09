using System;

namespace FakeInstagramBusinessLogic.Exceptions
{
    public class PostValidationException : Exception
    {
        public PostValidationException(string message) : base(message)
        {

        }
    }
}
