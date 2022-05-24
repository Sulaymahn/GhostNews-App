using System;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.Constants
{
    public enum SignupQueryResponse
    {
        Created,
        WeakPassword,
        AlreadyExists,
        InvalidEmail
    }
}
