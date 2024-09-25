namespace Dating.Domain.Exceptions
{
    public class NoAccessException : Exception
    {
        public NoAccessException() : base("The current user does not have access to the requested resource")
        { }
    }
}
