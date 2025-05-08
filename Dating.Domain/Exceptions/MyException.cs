namespace Dating.Domain.Exceptions
{
    public class MyException : Exception
    {
        public MyException(string error) : base (error) { }
    }

    public class NoAccessException : MyException
    {
        public NoAccessException() : base("The current user does not have access to the requested resource")
        { }
    }

    public class NotExistException : MyException
    {
        public NotExistException(string text) : base(text)
        {
        }

        public NotExistException(Type type, long id) : base($"The element({type}:{id}) does not exist")
        {
        }

        public NotExistException(Type type, string parameter, string value) : base($"The element({type}:{parameter}:{value}) does not exist")
        {
        }
    }

    public class ValidateException : MyException
    {
        public ValidateException(string text) : base(text)
        {
        }
    }
}
