using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Commands;

namespace UnitTests.Commands.CreateUserCommand
{
	[TestClass]
	public class CreateUserNotificationCommandHandlerTests
	{
		[TestMethod]
		public void CreateUserNotify()
		{
			// Act
			CreateUserNotificationCommandHandler commandHandler = new CreateUserNotificationCommandHandler();
			commandHandler.Execute(new DataModel.Commands.CreateUserCommand("User1", "User1", "user1@email.com"));


			// Assert
			// Exception should not throw
		}
	}
}