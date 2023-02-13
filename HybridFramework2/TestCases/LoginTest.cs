using HybridFramework2.Config;
using HybridFramework2.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework2.TestCases
{
    [TestFixture]
    internal class LoginTest : ReportsGenerationClass
    {
        LoginPage lp;

        [Test]
        [Category("Login")]
        public void InvalidLogin()
        {
            lp = new LoginPage(GetDriver());
            lp.GotoPage();
            lp.UpdateUserName("natarajan.test1@gmail.com");
            lp.ClickContinue();
        }

    }
}
