using System;

namespace ServerApi2
{
    public interface IAuth
    {
        string  Authentication(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
