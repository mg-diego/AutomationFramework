using OpenQA.Selenium;
using System.Collections.Generic;

namespace AC.Contracts
{
	/// <summary>
	/// Set up configuration.
	/// </summary>
	public interface ISetUp
	{
		string GetEnvironment();

		/// <summary>
		/// Launches the web driver.
		/// </summary>
		/// <returns>
		/// The <see cref="IWebDriver"/>
		/// </returns>
		IWebDriver LaunchDriver();

		/// <summary>
		/// Makes the screenshot.
		/// </summary>
		/// <param name="scenario">The scenario.</param>
		/// <returns>
		/// The <see cref="string"/>
		/// </returns>
		string MakeScreenshot(string stepName, string scenarioName);

		//string StaticMakeScreenshot(string scenario);

		/// <summary>
		/// Determines whether [is driver null].
		/// </summary>
		/// <returns>
		///   <c>true</c> if [is driver null]; otherwise, <c>false</c>.
		/// </returns>
		bool IsDriverNull();

		/// <summary>
		/// Closes the driver.
		/// </summary>
		void CloseDriver();


		/// <summary>
		/// Reopen the browser.
		/// </summary>
		void ReopenBrowser();

	}
}