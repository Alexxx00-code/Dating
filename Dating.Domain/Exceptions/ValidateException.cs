namespace Dating.Domain.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException(string text) : base(text)
        {
        }
    }
}
