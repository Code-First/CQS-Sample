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
	public class ActiveUsersQueryTests
	{
		[TestMethod]
		public void NoActiveUsers()
		{
			// Arrange
			IEnumerable<User> users = new[]
			{
				new User {Id = 1, FirstName = "User1", LastName = "User1", Email = "user1@email.com", IsActive = false},
				new User {Id = 2, FirstName = "User2", LastName = "User2", Email = "user2@email.com", IsActive = false},
				new User {Id = 3, FirstName = "User3", LastName = "User3", Email = "user3@email.com", IsActive = false}
			};

			ApplicationDbContext dbContext = new Mock<ApplicationDbContext>("Test")
				.SetupDbContextData(x => x.Users, users)
				.Build();


			// Act
			ActiveUsersQuery query = new ActiveUsersQuery(dbContext);
			IEnumerable<User> result = query.Execute();


			// Assert
			CollectionAssert.AreEqual(users.Where(x => x.IsActive).ToArray(), result.ToArray());
		}

		[TestMethod]
		public void OneActiveUser()
		{
			// Arrange
			IEnumerable<User> users = new[]
			{
				new User {Id = 1, FirstName = "User1", LastName = "User1", Email = "user1@email.com", IsActive = false},
				new User {Id = 2, FirstName = "User2", LastName = "User2", Email = "user2@email.com", IsActive = true},
				new User {Id = 3, FirstName = "User3", LastName = "User3", Email = "user3@email.com", IsActive = false}
			};

			ApplicationDbContext dbContext = new Mock<ApplicationDbContext>("Test")
				.SetupDbContextData(x => x.Users, users)
				.Build();


			// Act
			ActiveUsersQuery query = new ActiveUsersQuery(dbContext);
			IEnumerable<User> result = query.Execute();


			// Assert
			CollectionAssert.AreEqual(users.Where(x => x.IsActive).ToArray(), result.ToArray());
		}

		[TestMethod]
		public void TwoActiveUsers()
		{
			// Arrange
			IEnumerable<User> users = new[]
			{
				new User {Id = 1, FirstName = "User1", LastName = "User1", Email = "user1@email.com", IsActive = true},
				new User {Id = 2, FirstName = "User2", LastName = "User2", Email = "user2@email.com", IsActive = true},
				new User {Id = 3, FirstName = "User3", LastName = "User3", Email = "user3@email.com", IsActive = false}
			};

			ApplicationDbContext dbContext = new Mock<ApplicationDbContext>("Test")
				.SetupDbContextData(x => x.Users, users)
				.Build();


			// Act
			ActiveUsersQuery query = new ActiveUsersQuery(dbContext);
			IEnumerable<User> result = query.Execute();


			// Assert
			CollectionAssert.AreEqual(users.Where(x => x.IsActive).ToArray(), result.ToArray());
		}
	}
}