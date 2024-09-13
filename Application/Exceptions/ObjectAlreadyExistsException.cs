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
