using System.Collections.Generic;
using System.Linq;
using DataModel.Domain;
using EFDataAccess;
using EFDataAccess.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.Utils.EntityFramework;

namespace UnitTests.Commands.CreateUserCommand
{
	[TestClass]
	public class CreateUserCommandTests
	{
		[TestMethod]
		public void CreateUser()
		{
			IEnumerable<User> users = new User[] {};

			ApplicationDbContext dbContext = new Mock<ApplicationDbContext>("Test")
				.SetupDbContextData(x => x.Users, users)
				.Build();


			// Act
			CreateUserCommandHandler commandHandler = new CreateUserCommandHandler(dbContext);
			commandHandler.Execute(new DataModel.Commands.CreateUserCommand("User1", "User1", "user1@email.com"));


			// Assert
			User[] result = dbContext.Users.ToArray();
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual(1, result[0].Id);
			Assert.AreEqual("User1", result[0].FirstName);
			Assert.AreEqual("User1", result[0].LastName);
			Assert.AreEqual("user1@email.com", result[0].Email);
			Assert.AreEqual(false, result[0].IsActive);
		}
	}
}