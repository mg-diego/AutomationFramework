using DF.Entities;

namespace AC.Contracts.Pages
{
	/// <summary>
	/// The login page interface.
	/// </summary>
	/// <seealso cref="AC.Contracts.IPageBase" />
	public interface IContactosPage : IPageBase
	{

		void InsertNewContactData(string name, string email, int phoneNumber);

		bool IsAtContactos();

	}
}
