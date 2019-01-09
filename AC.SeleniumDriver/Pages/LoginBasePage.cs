using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Dashboard Login page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.ILoginBasePage" />
    public class LoginBasePage : PageBase, ILoginBasePage
    {
		#region .: Selenium WebDriver Elements :.

		[FindsBy(How = How.Id, Using = "i0116")]
		private IWebElement _inputEmail;

		[FindsBy(How = How.Id, Using = "i0118")]
		private IWebElement _inputPassword;

		[FindsBy(How = How.Id, Using = "idSIButton9")]
		private IWebElement _btnContinue;

		[FindsBy(How = How.Id, Using = "usernameError")]
		private IWebElement _txtUsernameError;

		[FindsBy(How = How.Id, Using = "idTD_Error")]
		private IWebElement _txtUnauthorizedError;

		[FindsBy(How = How.Id, Using = "passwordError")]
		private IWebElement _txtPasswordError;

		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="LoginBasePage"/> class.
		/// </summary>
		/// <param name="setUpWebDriver">The set up web driver.</param>
		public LoginBasePage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


		/// <summary>
		/// Click "Continue" button
		/// </summary>
		public void ClickContinueButton()
		{
			WaitUntilElementIsVisible(_btnContinue);
			this._btnContinue.Click();
		}

		/// <summary>
		/// Inserts a valid email at email login input
		/// </summary>
		public void InsertValidEmail()
		{
			WaitUntilElementIsVisible(_inputEmail);
			this._inputEmail.SendKeys("rentauser@djardi.onmicrosoft.com");
		}

		/// <summary>
		/// Inserts a valid password at password login input
		/// </summary>
		public void InsertValidPassword()
		{
			WaitUntilElementIsVisible(_inputPassword);
			this._inputPassword.SendKeys("Welcometoerni!");
		}

		/// <summary>
		/// Inserts an invalid password at password login input
		/// </summary>
		public void InsertInvalidPassword()
		{
			WaitUntilElementIsVisible(_inputPassword);
			this._inputPassword.SendKeys("asd!");
		}


		/// <summary>
		/// Inserts an invalid email at email login input
		/// </summary>
		public void InsertInvalidEmail()
		{
			WaitUntilElementIsVisible(_inputEmail);
			this._inputEmail.SendKeys("asd");
		}


		/// <summary>
		/// Inserts an invalid email at email login input
		/// </summary>
		public void InsertEmptyEmail()
		{
			WaitUntilElementIsVisible(_inputEmail);
			this._inputEmail.Clear();
		}

		/// <summary>
		/// Inserts an invalid email at email login input
		/// </summary>
		public void InsertUnauthorizedEmail()
		{
			WaitUntilElementIsVisible(_inputEmail);
			this._inputEmail.SendKeys("test@gmail.com");
		}


		/// <summary>
		/// Checks if invalid email message appears
		/// </summary>
		public bool IsAtInvalidEmail()
		{
			WaitUntilElementIsVisible(_txtUsernameError);

			Assert.Multiple(() =>
			{
				Assert.That(_txtUsernameError.Displayed, Is.EqualTo(true),"_txtUsernameError is not displayed");
			});

			return true;
		}

		/// <summary>
		/// Checks if invalid email message appears
		/// </summary>
		public bool IsAtUnauthorizedEmail()
		{
			WaitUntilElementIsVisible(_txtUnauthorizedError);

			Assert.Multiple(() =>
			{
				Assert.That(_txtUnauthorizedError.Displayed, Is.EqualTo(true), "_txtUnauthorizedError is not displayed");
			});

			return true;
		}

		/// <summary>
		/// Checks if invalid email message appears
		/// </summary>
		public bool IsAtInvalidPassword()
		{
			WaitUntilElementIsVisible(_txtPasswordError);

			Assert.Multiple(() =>
			{
				Assert.That(_txtPasswordError.Displayed, Is.EqualTo(true), "_txtPasswordError is not displayed");
			});

			return true;
		}


		/// <summary>
		/// Checks if input password is displayed
		/// </summary>
		public bool IsAtInputPassword()
		{
			WaitUntilElementIsVisible(_inputPassword);

			Assert.Multiple(() =>
			{
				Assert.That(_inputPassword.Displayed, Is.EqualTo(true), "_inputPassword is not displayed");
			});

			return true;
		}

	}
}

