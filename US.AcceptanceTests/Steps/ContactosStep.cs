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
	public class ContactosStep : StepBase
	{
		private readonly IContactosPage contactosPage;
		private readonly ISetUp setUp;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContactosStep" /> class.
		/// </summary>
		/// <param name="setUp">The set up.</param>
		/// <param name="contactosPage">The contactos page.</param>
		public ContactosStep(ISetUp setUp, IContactosPage contactosPage)
		{
			this.setUp = setUp;
			this.contactosPage = contactosPage;
		}

		/// <summary>
		/// Whens the user insert data for new user.
		/// </summary>
		[Then(@"The user is at Contactos tab")]
		public void TheUserIsAtContactosTab()
		{
			this.contactosPage.IsAtContactos().Equals(true);
		}

		/// <summary>
		/// Whens the user insert data for new user.
		/// </summary>
		[When(@"The user insert data for the new user")]
		public void WhenTheUserGoesToTheSelectEditCustomerPage()
		{
			this.contactosPage.InsertNewContactData("test", "test@test.com", 132);
		}

	}
}
