namespace Dating.Domain.Exceptions
{
    public class NotExistException : Exception
    {
        public NotExistException(Type type, long id) : base($"The element({type}:{id}) does not exist")
        {
        }

        public NotExistException(Type type, string parameter, string value) : base($"The element({type}:{parameter}:{value}) does not exist")
        {
        }
    }
}
