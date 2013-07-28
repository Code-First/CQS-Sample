using DataModel.Core;

namespace DataModel.Commands
{
	/// <summary>
	///     Create new inactive user
	/// </summary>
	public class CreateUserCommand : ICommand
	{
		public CreateUserCommand(string firstName, string lastName, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}

		public string FirstName { get; protected set; }
		public string LastName { get; protected set; }
		public string Email { get; protected set; }

		// Output parameter's setters marked as public
		public int Id { get; set; }
	}
}