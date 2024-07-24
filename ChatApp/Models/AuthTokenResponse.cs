using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class AuthTokenResponse
    {
        /// <summary>
        /// The access token
        /// </summary>
        public string access_token;
        /// <summary>
        /// The token type
        /// </summary>
        public string token_type;
        /// <summary>
        /// The expires in
        /// </summary>
        public string expires_in;
        /// <summary>
        /// The refresh token
        /// </summary>
        public string refresh_token;
    }
}
