using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework2.PageObjects
{
    internal class LoginPage
    {
        private IWebDriver driver;
        private By username_ip = By.Id("EmailPage-EmailField");
        private By continue_btn = By.XPath("//span[text()='Continue']");
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GotoPage()
        {
            driver.Url = "https://auth.services.adobe.com/en_US/index.html?callback=https%3A%2F%2Fims-na1.adobelogin.com%2Fims%2Fadobeid%2Fadobedotcom2%2FAdobeID%2Ftoken%3Fredirect_uri%3Dhttps%253A%252F%252Fwww.adobe.com%252Fin%252F%2523old_hash%253D%2526from_ims%253Dtrue%253Fclient_id%253Dadobedotcom2%2526api%253Dauthorize%2526scope%253DAdobeID%252Copenid%252Cgnav%252Cread_organizations%252Cadditional_info.projectedProductContext%252Cadditional_info.roles%26state%3D%257B%2522ac%2522%253A%2522%2522%252C%2522jslibver%2522%253A%2522v2-v0.38.0-17-g633319d%2522%252C%2522nonce%2522%253A%25223539394812405384%2522%257D%26code_challenge_method%3Dplain%26use_ms_for_expiry%3Dtrue&client_id=adobedotcom2&scope=AdobeID%2Copenid%2Cgnav%2Cread_organizations%2Cadditional_info.projectedProductContext%2Cadditional_info.roles&denied_callback=https%3A%2F%2Fims-na1.adobelogin.com%2Fims%2Fdenied%2Fadobedotcom2%3Fredirect_uri%3Dhttps%253A%252F%252Fwww.adobe.com%252Fin%252F%2523old_hash%253D%2526from_ims%253Dtrue%253Fclient_id%253Dadobedotcom2%2526api%253Dauthorize%2526scope%253DAdobeID%252Copenid%252Cgnav%252Cread_organizations%252Cadditional_info.projectedProductContext%252Cadditional_info.roles%26response_type%3Dtoken%26state%3D%257B%2522ac%2522%253A%2522%2522%252C%2522jslibver%2522%253A%2522v2-v0.38.0-17-g633319d%2522%252C%2522nonce%2522%253A%25223539394812405384%2522%257D&state=%7B%22ac%22%3A%22%22%2C%22jslibver%22%3A%22v2-v0.38.0-17-g633319d%22%2C%22nonce%22%3A%223539394812405384%22%7D&relay=c09b9fd8-903d-48cd-be7b-e29c94886a0d&locale=en_US&flow_type=token&idp_flow_type=login&ab_test=no-country-flag-row%2Csignin-failure-guidance-links&s_p=google%2Cfacebook%2Capple&response_type=token#/";
        }

        public void UpdateUserName(String username)
        {
            driver.FindElement(username_ip).SendKeys(username);
        }

        public void ClickContinue()
        {
            driver.FindElement(continue_btn).Click();
        }
    }
}
