using System;
using System.Collections.Generic;
using System.Text;

namespace lb7.SocialAuthorization
{
    public interface ISocialAuthorization
    {
        string ProviderName { get; }
        string[] DemoAccounts { get; }
    }
}
