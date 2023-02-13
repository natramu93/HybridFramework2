using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Interfaces;

namespace HybridFramework2.Config
{
    [SetUpFixture]
    public abstract class ReportsGenerationClass
    {
        protected ExtentReports extent;
        protected ExtentTest test;
        public IWebDriver driver;

        [OneTimeSetUp]
        protected void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() +"Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Env", "QA");
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = TestContext.CurrentContext.Test.Name+"_" + time.ToString("dd_MM_yyyy_h_mm_ss") + ".png";
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below:");
                    test.AddScreenCaptureFromPath("Screenshots\\" + fileName);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stackTrace);
            extent.Flush();
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public static string Capture(IWebDriver driver,String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\Screenshots");
            var finalPath = path.Substring(0, path.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(finalPath,ScreenshotImageFormat.Png);
            return reportPath;
        }

    }
}
