using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class OauthToken
    {
        public string Ckey { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
