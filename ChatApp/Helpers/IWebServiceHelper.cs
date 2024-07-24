using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Helpers
{
    internal interface IWebServiceHelper
    {
        Task<bool> Login(string tenantName, string userName, string password);
    }
}
