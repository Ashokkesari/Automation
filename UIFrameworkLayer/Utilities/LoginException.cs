using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkLayer.Utilities
{
    public class LoginException : Exception
    {
        public LoginException() : base($"Failed to login SwagLab") { }

        public LoginException(string username, Exception password): base($"Failed to login swaglab with Username: {username}, Password: {password}") { }

    }

}
