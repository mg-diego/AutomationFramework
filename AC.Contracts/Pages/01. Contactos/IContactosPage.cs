using DF.Entities;

namespace AC.Contracts.Pages
{
	/// <summary>
	/// The login page interface.
	/// </summary>
	/// <seealso cref="AC.Contracts.IPageBase" />
	public interface IContactosPage : IPageBase
	{
		void ClickCrearContacto();

		bool IsAtContactos();

		void FilterContactData(string name, string email, int phoneNumber);

	}
}
