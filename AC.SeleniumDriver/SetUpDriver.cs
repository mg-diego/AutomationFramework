using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Diagnostics;
using NUnit.Framework;

namespace AC.SeleniumDriver
{
	public class SetUpDriver : ISetUp
	{
		private const string DriverPath = @"\binaries\";
		private static ChromeDriver chromeWebDriver;
		private static FirefoxDriver firefoxWebDriver;
		private static InternetExplorerDriver ieWebDriver;

		// ENVIRONMENTS
		public string environment = "http://localhost:4200/contactos";


		WebBrowser webBrowser = WebBrowser.Chrome;
		//WebBrowser webBrowser = WebBrowser.Firefox;
		//WebBrowser webBrowser = WebBrowser.IE;

		public static string initialTime = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm", CultureInfo.InvariantCulture);
		public string executionTime = DateTime.UtcNow.ToString("HH-mm-ss", CultureInfo.InvariantCulture);


		public string executionFolder = "";

		private enum WebBrowser
		{
			/// <summary>
			/// The chrome.
			/// </summary>
			Chrome,

			/// <summary>
			/// The Firefox.
			/// </summary>
			Firefox,

			/// <summary>
			/// The IE.
			/// </summary>
			IE
		}

		public SetUpDriver()
		{

		}

		#region .: General Methods :.

		public string GetEnvironment() { return environment; }

		/// <summary>
		/// Closes the driver.
		/// </summary>
		public void CloseDriver()
		{
			switch (webBrowser)
			{
				case WebBrowser.Chrome:
					chromeWebDriver.Quit();
					chromeWebDriver.Dispose();
					chromeWebDriver = null;
					break;
				case WebBrowser.Firefox:
					firefoxWebDriver.Quit();
					firefoxWebDriver.Dispose();
					firefoxWebDriver = null;
					break;
				case WebBrowser.IE:
					ieWebDriver.Quit();
					ieWebDriver.Dispose();
					ieWebDriver = null;
					break;
			}

		}

		/// <summary>
		/// Launches the web driver.
		/// </summary>
		/// <returns>The <see cref="IWebDriver"/></returns>
		public IWebDriver LaunchDriver()
		{
			switch (webBrowser)
			{
				case WebBrowser.Chrome:
					return SetUpSeleniumChromeWebDriver();

				case WebBrowser.Firefox:
					return SetUpSeleniumFirefoxWebDriver();

				case WebBrowser.IE:
					return SetUpSeleniumIeWebDriver();

				default:
					return SetUpSeleniumChromeWebDriver();
			}
		}

		/// <summary>
		/// Makes the screenshot.
		/// </summary>
		/// <param name="stepName">The scenario.</param>
		/// <returns>The <see cref="string"/></returns>
		public string MakeScreenshot(string stepName, string scenarioName)
		{
			var FolderName = $"{executionTime}_{scenarioName}";
			if (FolderName.Length > 25)
				FolderName = FolderName.Substring(0, 25);
			executionFolder = initialTime;

			var binDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			binDirectory = binDirectory.Substring(0, binDirectory.Length - ("\\US.AcceptanceTests\\bin\\Debug".Length));

			binDirectory = binDirectory + @"\TestResults\" + executionFolder + "\\" + FolderName;
			CreateScreenShotFolder(binDirectory);
			var screenshotName = $"{DateTime.UtcNow.ToString("HH-mm-ss", CultureInfo.InvariantCulture)}_{stepName}";

			if (screenshotName.Length > 150)
				screenshotName = screenshotName.Substring(0, 150);

			screenshotName = screenshotName + ".jpeg";

			var fullPathFile = Path.Combine(binDirectory, screenshotName);

			//var fullPathFile = binDirectory + @"\" + screenshotName;

			Screenshot screenshot = new Screenshot("");

			switch (webBrowser)
			{
				case WebBrowser.Chrome:
					screenshot = ((ITakesScreenshot)chromeWebDriver).GetScreenshot();
					break;
				case WebBrowser.Firefox:
					screenshot = ((ITakesScreenshot)firefoxWebDriver).GetScreenshot();
					break;
				case WebBrowser.IE:
					screenshot = ((ITakesScreenshot)ieWebDriver).GetScreenshot();
					break;
			}

			//screenshot.SaveAsFile(fullPathFile, ScreenshotImageFormat.Jpeg);
			//TestContext.AddTestAttachment(fullPathFile);

			return fullPathFile;
		}

		/// <summary>
		/// Creates the screen shot folder.
		/// </summary>
		/// <param name="path">The path.</param>
		private void CreateScreenShotFolder(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}

		/// <summary>
		/// Determines whether [is web driver null].
		/// </summary>
		/// <returns>
		/// <c>true</c> if [is web driver null]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsDriverNull()
		{
			switch (webBrowser)
			{
				case WebBrowser.Chrome:
					return chromeWebDriver == null;
				case WebBrowser.Firefox:
					return firefoxWebDriver == null;
				case WebBrowser.IE:
					return ieWebDriver == null;
				default:
					return chromeWebDriver == null;
			}
		}

		public void ReopenBrowser()
		{
			switch (webBrowser)
			{
				case WebBrowser.Chrome:
					SetUpSeleniumChromeWebDriver();
					break;
				case WebBrowser.Firefox:
					SetUpSeleniumFirefoxWebDriver();
					break;
				case WebBrowser.IE:
					SetUpSeleniumIeWebDriver();
					break;
				default:
					SetUpSeleniumChromeWebDriver();
					break;
			}
		}

		public void ClearAllCookies()
		{
			chromeWebDriver.Manage().Cookies.DeleteAllCookies();
			switch (webBrowser)
			{
				case WebBrowser.Chrome:
					chromeWebDriver.Manage().Cookies.DeleteAllCookies();
					break;
				case WebBrowser.Firefox:
					firefoxWebDriver.Manage().Cookies.DeleteAllCookies();
					break;
				case WebBrowser.IE:
					ieWebDriver.Manage().Cookies.DeleteAllCookies();
					break;
				default:
					chromeWebDriver.Manage().Cookies.DeleteAllCookies();
					break;
			}
		}

		#endregion



		#region .: Chrome Web Driver :.

		private IWebDriver SetUpSeleniumChromeWebDriver()
		{
			try
			{
				if (chromeWebDriver != null)
				{
					return chromeWebDriver;
				}

				chromeWebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath);
				chromeWebDriver.Manage().Cookies.DeleteAllCookies();
				chromeWebDriver.Manage().Window.Maximize();

				chromeWebDriver.Navigate().GoToUrl(environment);

				return chromeWebDriver;
			}
			catch (Exception ex)
			{
				CloseDriver();
				throw new Exception("Set up chrome web driver has failed", ex);
			}
		}


		#endregion

		#region .: Firefox Web Driver :.

		private IWebDriver SetUpSeleniumFirefoxWebDriver()
		{
			try
			{
				if (firefoxWebDriver != null)
				{
					return firefoxWebDriver;
				}

				firefoxWebDriver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath);
				firefoxWebDriver.Manage().Cookies.DeleteAllCookies();
				firefoxWebDriver.Manage().Window.Maximize();

				//--- LOCALHOST ---//
				firefoxWebDriver.Navigate().GoToUrl("http://localhost:4200/login");

				return firefoxWebDriver;
			}
			catch (Exception ex)
			{
				CloseDriver();
				throw new Exception("Set up firefox web driver has failed", ex);
			}
		}

		#endregion

		#region .: Internet Explorer Web Driver :.

		private IWebDriver SetUpSeleniumIeWebDriver()
		{
			try
			{
				if (ieWebDriver != null)
				{
					return ieWebDriver;
				}

				InternetExplorerOptions caps = new InternetExplorerOptions();
				caps.IgnoreZoomLevel = true;

				ieWebDriver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath, caps);
				ieWebDriver.Manage().Cookies.DeleteAllCookies();
				ieWebDriver.Manage().Window.Maximize();

				//--- LOCALHOST ---//
				ieWebDriver.Navigate().GoToUrl("http://localhost:4200/login");

				return ieWebDriver;
			}
			catch (Exception ex)
			{
				CloseDriver();
				throw new Exception("Set up internet explorer web driver has failed", ex);
			}
		}

		#endregion



	}
}