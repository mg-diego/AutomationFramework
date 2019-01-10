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
using NUnit.Framework;

namespace AC.SeleniumDriver.Pages
{
	/// <summary>
	/// The Dashboard Login page.
	/// </summary>
	/// <seealso cref="AC.SeleniumDriver.PageBase" />
	/// <seealso cref="AC.Contracts.Pages.ICrearContactoPage" />
	public class CrearContactoPage : PageBase, ICrearContactoPage
	{
		#region .: Selenium WebDriver Elements :.

		//Inputs
		[FindsBy(How = How.XPath, Using = "//*[@formcontrolname='nombre']")]
		private IWebElement _inputName;

		[FindsBy(How = How.XPath, Using = "//*[@formcontrolname='email']")]
		private IWebElement _inputEmail;

		[FindsBy(How = How.XPath, Using = "//*[@formcontrolname='telefono']")]
		private IWebElement _inputPhone;


		//Mandatory Info
		[FindsBy(How = How.XPath, Using = "//*[contains(@id,'mat-error')]")]
		private IWebElement _alertMandatoryName;

		[FindsBy(How = How.XPath, Using = "//*[contains(@id,'mat-error')]")]
		private IWebElement _alertMandatoryEmail;

		[FindsBy(How = How.XPath, Using = "//*[contains(@id,'mat-error')]")]
		private IWebElement _alertMandatoryPhone;


		//Buttons
		[FindsBy(How = How.XPath, Using = "//*[@type='button']")]
		private IWebElement _btnCancel;

		[FindsBy(How = How.XPath, Using = "//*[@type='submit']")]
		private IWebElement _btnSave;

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginBasePage"/> class.
		/// </summary>
		/// <param name="setUpWebDriver">The set up web driver.</param>
		public CrearContactoPage(ISetUp setUpWebDriver)
			: base(setUpWebDriver)
		{
			PageFactory.InitElements(webDriver, this);
		}

		#region .: New Contact :.

		/// <summary>
		/// Checks if invalid email message appears
		/// </summary>
		public bool IsAtNewContact()
		{
			Assert.Multiple(() =>
			{
				Assert.That(_inputName.Displayed, Is.EqualTo(true), "_inputName is not displayed");
				Assert.That(_inputEmail.Displayed, Is.EqualTo(true), "_inputEmail is not displayed");
				Assert.That(_inputPhone.Displayed, Is.EqualTo(true), "_inputPhone is not displayed");
			});

			return true;
		}

		/// <summary>
		/// Insert New Contact name.
		/// </summary>
		/// <param name="name">The customer name.</param>
		public void InsertNewContactName(string name)
		{
			this._inputName.SendKeys(name);
		}

		/// <summary>
		/// Insert New Contact name.
		/// </summary>
		/// <param name="email">The customer name.</param>
		public void InsertNewContactEmail(string email)
		{
			this._inputName.SendKeys(email);
		}

		/// <summary>
		/// Insert New Contact name.
		/// </summary>
		/// <param name="phone">The customer name.</param>
		public void InsertNewContactPhone(string phone)
		{
			this._inputName.SendKeys(phone);
		}

		/// <summary>
		/// Clear New Contact name.
		/// </summary>
		/// <param name="name">The customer name.</param>
		public void ClearNewContactName()
		{
			this._inputName.Clear();
		}

		/// <summary>
		/// Clear New Contact name.
		/// </summary>
		/// <param name="email">The customer name.</param>
		public void ClearNewContactEmail()
		{
			this._inputName.Clear();
		}

		/// <summary>
		/// Clear New Contact name.
		/// </summary>
		/// <param name="phone">The customer name.</param>
		public void ClearNewContactPhone()
		{
			this._inputName.Clear();
		}


		/// <summary>
		/// Checks if mandatory new contact name error message appears
		/// </summary>
		public bool IsMandatoryNameErrorMessageVisible()
		{
			WaitUntilElementIsVisible(_alertMandatoryName);

			Assert.Multiple(() =>
			{
				Assert.That(_alertMandatoryName.Displayed, Is.EqualTo(true), "_alertMandatoryName text is not displayed");
				Assert.That(_alertMandatoryName.Text, Is.EqualTo("El nombre es necesario"), "_alertMandatoryName text is not 'El nombre es necesario'");
			});

			return true;
		}

		/// <summary>
		/// Checks if mandatory new contact email error message appears
		/// </summary>
		public bool IsMandatoryEmailErrorMessageVisible()
		{
			WaitUntilElementIsVisible(_alertMandatoryEmail);

			Assert.Multiple(() =>
			{
				Assert.That(_alertMandatoryEmail.Displayed, Is.EqualTo(true), "_alertMandatoryEmail text is not displayed");
				Assert.That(_alertMandatoryEmail.Text, Is.EqualTo("El nombre es necesario"), "_alertMandatoryEmail text is not 'El correo electrónico es necesario'");
			});

			return true;
		}

		/// <summary>
		/// Checks if mandatory new contact name error message appears
		/// </summary>
		public bool IsMandatoryPhoneErrorMessageVisible()
		{
			WaitUntilElementIsVisible(_alertMandatoryPhone);

			Assert.Multiple(() =>
			{
				Assert.That(_alertMandatoryPhone.Displayed, Is.EqualTo(true), "_alertMandatoryPhone text is not displayed");
				Assert.That(_alertMandatoryPhone.Text, Is.EqualTo("El nombre es necesario"), "_alertMandatoryPhone text is not 'El teléfono es necesario'");
			});

			return true;
		}

		public void ClickCancelButton()
		{
			this._btnCancel.Click();
		}

		public void ClickSaveButton()
		{
			this._btnSave.Click();
		}

		#endregion
	}
}
