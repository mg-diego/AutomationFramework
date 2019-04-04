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

namespace US.AcceptanceTests.Steps.Login
{
    /// <summary>
    /// The dashboard login steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class LoginBaseSteps : StepBase
    {
        private readonly ILoginBasePage loginBasePage;
        private readonly ISetUp setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginBaseSteps" /> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>
        /// <param name="LoginBasePage">The login page.</param>
        public LoginBaseSteps(ISetUp setUp, ILoginBasePage loginBasePage)
        {
            this.setUp = setUp;
            this.loginBasePage = loginBasePage;
        }


		/// <summary>
		/// A valid user completes the login process
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Given(@"A valid user completes the login process")]
		public void UserCompletesLoginProcess()
		{
			TheUserIntroducesEmail("valid");
			TheUserClicksContinueButton();
			TheUserIntroducesPassword("valid");
			TheUserClicksContinueButton();
			TheUserClicksContinueButton();
		}


		/// <summary>
		/// The user clicks in Continue button
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[When(@"The user clicks continue button")]
		[When(@"The user confirms the login")]
		[When(@"The user clicks Login button")]
		public void TheUserClicksContinueButton()
		{
			loginBasePage.ClickContinueButton();
		}


		[Then(@"The user is at homepage")]
		public void ThenTheUserIsAtHomepage()
		{
			loginBasePage.IsAtHomepage();
		}



		/// <summary>
		/// The user introduces a <type> email.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user introduces a '(.*)' email")]
		[When(@"The user introduces a '(.*)' email")]
		public void TheUserIntroducesEmail(string emailType)
        {
			switch (emailType)
			{
				case "valid":
					this.loginBasePage.InsertValidUser();
					break;
				case "invalid":
					this.loginBasePage.InsertInvalidEmail();
					break;
				case "empty":
					this.loginBasePage.InsertEmptyEmail();
					break;
				case "unauthorized":
					this.loginBasePage.InsertUnauthorizedEmail();
					break;

				default:
					throw new InvalidOperationException("Unknown email type '" + emailType + "'.");
			}
		}

		/// <summary>
		/// The user introduces a <type> password.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Given(@"The user introduces a '(.*)' password")]
		[When(@"The user introduces a '(.*)' password")]
		public void TheUserIntroducesPassword(string passwordType)
		{
			switch (passwordType)
			{
				case "valid":
					this.loginBasePage.InsertValidPassword();
					break;
				case "invalid":
					this.loginBasePage.InsertInvalidPassword();
					break;
				default:
					throw new InvalidOperationException("Unknown password type '" + passwordType + "'.");
			}
		}


		/// <summary>
		/// The an invalid user message appears.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Then(@"The invalid user message appears")]
		public void InvalidEmailMessaAppears()
		{
			loginBasePage.IsAtInvalidEmail().Equals(true);
		}


		/// <summary>
		/// The an invalid password message appears.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Then(@"The invalid password message appears")]
		public void InvalidPasswordlMessaAppears()
		{
			loginBasePage.IsAtInvalidPassword().Equals(true);
		}

		/// <summary>
		/// The unauthorized user message appears.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Then(@"The unauthorized error message appears")]
		public void UnauthorizedErrorMessageAppears()
		{
			loginBasePage.IsAtUnauthorizedEmail().Equals(true);
		}

		/// <summary>
		/// The password input appears
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Then(@"The password input appears")]
		public void ThePasswordInputAppears()
		{
			loginBasePage.IsAtInputPassword().Equals(true);
		}





		/// <summary>
		/// The after scenario.
		/// </summary>
		[AfterScenario]
        public void AfterScenario()
        {
			setUp.CloseDriver();

			try
            {
                // Take a screenshot.
                //var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title, "");
                //CurrentTestContext.AddResultFile(screenshotPathFile);               
            }
            catch
            {
                setUp.CloseDriver();
            }
		}


		/// <summary>
		/// The clean test run.
		/// </summary>
		[AfterStep]
		public void AfterStepMakeScreenShot()
		{
			//Console.WriteLine("AfterStep");
			//Thread.Sleep(TimeSpan.FromSeconds(1));
			//var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString(), ScenarioContext.Current.ScenarioInfo.Title);
			//CurrentTestContext.AddResultFile(screenshotPathFile);
		}

		/// <summary>
		/// Before the scenario for AfterscenarioWithResetBrowser tag.
		/// </summary>
		[AfterScenario("@AfterscenarioWithResetBrowser")]
        public void AfterScenarioWithResetBrowser()
        {
            AfterScenario();
            setUp.CloseDriver();
            setUp.ReopenBrowser();
        }


        /// <summary>
        /// The clean test run.
        /// </summary>
        [AfterTestRun]
        public static void CleanTestRun()
        {
            AppContainer.Container.Resolve<ISetUp>().CloseDriver();
        }

    }
}
