using System.Collections.Generic;
using System.Linq;
using DataModel.Domain;
using EFDataAccess;
using EFDataAccess.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.Utils.EntityFramework;

namespace UnitTests.Queries
{
	[TestClass]
	public class UserByEmailQueryTests
	{
		[TestMethod]
		public void ExistingUser()
		{
			// Arrange
			IEnumerable<User> users = new[]
			{
				new User {Id = 1, FirstName = "User1", LastName = "User1", Email = "user1@email.com", IsActive = true},
				new User {Id = 2, FirstName = "User2", LastName = "User2", Email = "user2@email.com", IsActive = true},
				new User {Id = 3, FirstName = "User3", LastName = "User3", Email = "user3@email.com", IsActive = true}
			};

			ApplicationDbContext dbContext = new Mock<ApplicationDbContext>("Test")
				.SetupDbContextData(x => x.Users, users)
				.Build();


			// Act
			User userToSearch = users.Skip(1).First();

			UserByEmailQuery query = new UserByEmailQuery(dbContext);
			User result = query.Execute(userToSearch.Email);


			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(userToSearch.Id, result.Id);
			Assert.AreEqual(userToSearch.FirstName, result.FirstName);
			Assert.AreEqual(userToSearch.LastName, result.LastName);
			Assert.AreEqual(userToSearch.Email, result.Email);
			Assert.AreEqual(userToSearch.IsActive, result.IsActive);
		}

		[TestMethod]
		public void UnknownUser()
		{
			// Arrange
			IEnumerable<User> users = new[]
			{
				new User {Id = 1, FirstName = "User1", LastName = "User1", Email = "user1@email.com", IsActive = true},
				new User {Id = 2, FirstName = "User2", LastName = "User2", Email = "user2@email.com", IsActive = true},
				new User {Id = 3, FirstName = "User3", LastName = "User3", Email = "user3@email.com", IsActive = true}
			};

			ApplicationDbContext dbContext = new Mock<ApplicationDbContext>("Test")
				.SetupDbContextData(x => x.Users, users)
				.Build();


			// Act
			UserByEmailQuery query = new UserByEmailQuery(dbContext);
			User result = query.Execute("user4@email.com");


			// Assert
			Assert.IsNull(result);
		}
	}
}