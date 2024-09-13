namespace Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public string message;
        public BadRequestException(string message) : base(message)
        {
            this.message = message;
        }
    }
}
