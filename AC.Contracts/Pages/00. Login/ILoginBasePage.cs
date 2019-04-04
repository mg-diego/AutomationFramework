using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The login page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface ILoginBasePage : IPageBase
    {
		void ClickContinueButton();

		void InsertValidUser();

		void InsertValidPassword();

		void InsertEmptyEmail();

		void InsertUnauthorizedEmail();

		void InsertInvalidEmail();

		void InsertInvalidPassword();

		bool IsAtInvalidEmail();

		bool IsAtInputPassword();

		bool IsAtUnauthorizedEmail();

		bool IsAtInvalidPassword();

		bool IsAtHomepage();
	}
}
