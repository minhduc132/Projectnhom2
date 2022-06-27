namespace Api3
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}
