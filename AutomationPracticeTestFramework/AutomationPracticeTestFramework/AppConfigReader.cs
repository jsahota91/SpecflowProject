﻿using System;
using System.Configuration;

namespace AutomationPracticeTestFramework
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string SignInPageUrl = ConfigurationManager.AppSettings["signinpage_url"];
        public static readonly string CreateAccountUrl = ConfigurationManager.AppSettings["createacc_url"];
        public static readonly string ForgotPasswordUrl = ConfigurationManager.AppSettings["forgotpass_url"];
    }
}
