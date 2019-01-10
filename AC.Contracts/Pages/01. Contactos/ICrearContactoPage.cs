using DF.Entities;

namespace AC.Contracts.Pages
{
	/// <summary>
	/// The login page interface.
	/// </summary>
	/// <seealso cref="AC.Contracts.IPageBase" />
	public interface ICrearContactoPage : IPageBase
	{

		bool IsAtNewContact();

		void InsertNewContactName(string name);
		void ClearNewContactName();

		void InsertNewContactEmail(string email);
		void ClearNewContactEmail();

		void InsertNewContactPhone(string phone);
		void ClearNewContactPhone();

		bool IsMandatoryNameErrorMessageVisible();

		bool IsMandatoryEmailErrorMessageVisible();

		bool IsMandatoryPhoneErrorMessageVisible();

		void ClickCancelButton();
		void ClickSaveButton();


	}
}
