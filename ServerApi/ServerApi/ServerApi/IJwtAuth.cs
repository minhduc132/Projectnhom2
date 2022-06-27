namespace ServerApi
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}

