using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace lb7.SocialAuthorization
{
    public class FacebookAuthorization : ISocialAuthorization
    {
        public string ProviderName => "Facebook";

        public string[] DemoAccounts =>
        [
            "Student User",
            "Demo Account",
            "Test User"
        ];
    }
}
