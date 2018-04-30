namespace CodeChallenge.Infrastructure
{
    public interface ISanitizable
    {
        bool IsNotEmpty(string message, out string parsedMessage);
    }
}
