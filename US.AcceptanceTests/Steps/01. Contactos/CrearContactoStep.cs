using System;
using System.Diagnostics.CodeAnalysis;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Containers;
using DF.Entities;
using FluentAssertions;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps
{
	/// <summary>
	/// The Contactos page steps.
	/// </summary>
	/// <seealso cref="UserStories.AcceptanceTest.Steps.Base.BaseStep" />
	[Binding]
	public class CrearContactoStep : StepBase
	{
		private readonly ICrearContactoPage crearContactoPage;
		private readonly ISetUp setUp;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContactosStep" /> class.
		/// </summary>
		/// <param name="setUp">The set up.</param>
		/// <param name="crearContactoPage">The contactos page.</param>
		public CrearContactoStep(ISetUp setUp, ICrearContactoPage crearContactoPage)
		{
			this.setUp = setUp;
			this.crearContactoPage = crearContactoPage;
		}


		/// <summary>
		/// When The user creates new user without <field>.
		/// <param name="fieldToClean">The emptyField mandatory parameter.</param>
		/// </summary>
		[When(@"The user creates new user without '(.*)'")]
		public void NewUserWithoutField(string fieldToClean)
		{
			switch (fieldToClean)
			{
				case "name":
					this.crearContactoPage.InsertNewContactName("");
					this.crearContactoPage.ClearNewContactName();					
					break;
				case "email":
					this.crearContactoPage.InsertNewContactEmail("");
					this.crearContactoPage.ClearNewContactEmail();
					break;
				case "phone":
					this.crearContactoPage.InsertNewContactPhone("");
					this.crearContactoPage.ClearNewContactPhone();
					break;

				default:
					throw new InvalidOperationException("Unknown field type '" + fieldToClean + "'.");
			}

			// TO DO: Once Guardar button works change the logic to trigger the message
			this.crearContactoPage.ClickCancelButton();
		}

		/// <summary>
		/// Then Error message for '<field>' mandatory field appears.
		/// <param name="mandatoryField">The mandatoryField mandatory parameter.</param>
		/// </summary>
		[Then(@"Error message for '(.*)' mandatory field appears")]
		public void MandatoryFieldErrorMessageAppears(string mandatoryField)
		{
			switch (mandatoryField)
			{
				case "name":
					this.crearContactoPage.IsMandatoryNameErrorMessageVisible().Equals(true);
					break;
				case "email":
					this.crearContactoPage.IsMandatoryEmailErrorMessageVisible().Equals(true);
					break;
				case "phone":
					this.crearContactoPage.IsMandatoryPhoneErrorMessageVisible().Equals(true);
					break;

				default:
					throw new InvalidOperationException("Unknown field type '" + mandatoryField + "'.");
			}

		}		


		/// <summary>
		/// The user is at Create New Contact.
		/// </summary>
		[Then(@"The user is at Create New Contact")]
		public void WhenTheUserGoesToTheSelectEditCustomerPage()
		{
			this.crearContactoPage.IsAtNewContact().Equals(true);
		}

	}
}
