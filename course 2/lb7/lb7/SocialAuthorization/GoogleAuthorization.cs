using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace lb7.SocialAuthorization
{
    public class GoogleAuthorization : ISocialAuthorization
    {
        public string ProviderName => "Google";

        public string[] DemoAccounts =>
        [
            "user@gmail.com",
            "student@gmail.com",
            "example@gmail.com"
        ];
    }
}