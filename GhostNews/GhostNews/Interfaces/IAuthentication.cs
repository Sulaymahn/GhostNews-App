using GhostNews.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GhostNews.Interfaces
{
    public interface IAuthentication
    {
        Task<LoginQueryResponse> LoginWithEmailAndPassword(string email, string password);
        Task<SignupQueryResponse> RegisterUser(string email, string password);
        bool SignOut();
        bool IsSignIn();
        string GetUID();
    }
}
