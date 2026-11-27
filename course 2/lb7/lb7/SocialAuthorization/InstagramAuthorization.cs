using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace lb7.SocialAuthorization
{
    public class InstagramAuthorization : ISocialAuthorization
    {
        public string ProviderName => "Instagram";

        public string[] DemoAccounts =>
        [
            "@student",
            "@demo_user",
            "@test_account"
        ];
    }
}
