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
	/// <seealso cref="AC.Contracts.Pages.IContactosPage" />
	public class ContactosPage : PageBase, IContactosPage
	{
		#region .: Selenium WebDriver Elements :.

		/// <summary>
		/// The customer identifier text box.
		/// </summary>
		[FindsBy(How = How.XPath, Using = "//*[@ref='eColumnFloatingFilter']")]
		private IList<IWebElement> _inputs;

		[FindsBy(How = How.XPath, Using = "//*[@routerlink='/contactos/nuevo']")]
		private IWebElement _btnNewContact;

		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="LoginBasePage"/> class.
		/// </summary>
		/// <param name="setUpWebDriver">The set up web driver.</param>
		public ContactosPage(ISetUp setUpWebDriver)
			: base(setUpWebDriver)
		{
			PageFactory.InitElements(webDriver, this);
		}


		/// <summary>
		/// Checks if invalid email message appears
		/// </summary>
		public bool IsAtContactos()
		{
			WaitUntilElementIsVisible(_btnNewContact);

			Assert.Multiple(() =>
			{
				Assert.That(_btnNewContact.Text, Is.EqualTo("Crear Contacto"), "_btnNewContact text is not 'Crear Contacto'");
				Assert.That(_btnNewContact.Displayed, Is.EqualTo(true), "_btnNewContact is not displayed");
			});

			return true;
		}

		/// <summary>
		/// Creates the saving account.
		/// </summary>
		/// <param name="name">The customer name.</param>
		/// <param name="email">The customer email.</param>
		/// <param name="phoneNumber">The phone number.</param>
		public void InsertNewContactData(string name, string email, int phoneNumber)
		{
			this._inputs[0].SendKeys(name);
			this._inputs[1].SendKeys(email);
			this._inputs[2].SendKeys(phoneNumber.ToString());
		}
	}
}
