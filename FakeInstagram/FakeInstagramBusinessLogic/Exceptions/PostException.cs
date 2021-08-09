using System;

namespace FakeInstagramBusinessLogic.Exceptions
{
    public class PostException : NullReferenceException
    {
        public PostException(string message) : base(message)
        {

        }
    }
}
