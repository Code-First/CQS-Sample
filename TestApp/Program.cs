using System;
using System.Collections.Generic;
using DataModel.Commands;
using DataModel.Core;
using DataModel.Domain;
using DataModel.Queries;
using TestApp.IoC;

namespace TestApp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			// Getting the factories
			IQueryFactory queryFactory = Container.Current.Resolve<IQueryFactory>();
			ICommandsFactory commandsFactory = Container.Current.Resolve<ICommandsFactory>();


			// Executing commands
			Console.WriteLine("Crating new user...");

			CreateUserCommand createUserCommand = new CreateUserCommand(
				Guid.NewGuid().ToString().ToUpperInvariant().Replace("-", "").Substring(0, 6),
				Guid.NewGuid().ToString().ToUpperInvariant().Replace("-", "").Substring(0, 6),
				Guid.NewGuid().ToString().ToUpperInvariant().Replace("-", "").Substring(0, 6) + "@email.com");
			commandsFactory.ExecuteQuery(createUserCommand);

			Console.WriteLine("User created with Id = {0}", createUserCommand.Id);
			Console.WriteLine();


			// Executing queries
			IEnumerable<User> activeUsers = queryFactory
				.ResolveQuery<IActiveUsersQuery>()
				.Execute();

			Console.WriteLine("Active users: ");
			foreach (User t in activeUsers)
			{
				Console.WriteLine("{0} {1} {2} {3}", t.Id, t.LastName, t.FirstName, t.Email);
			}
			Console.WriteLine();


			IEnumerable<User> inactiveUsers = queryFactory
				.ResolveQuery<IInactiveUsersQuery>()
				.Execute();

			Console.WriteLine("Inactive users: ");
			foreach (User t in inactiveUsers)
			{
				Console.WriteLine("{0} {1} {2} {3}", t.Id, t.LastName, t.FirstName, t.Email);
			}
			Console.WriteLine();


			User user = queryFactory
				.ResolveQuery<IUserByEmailQuery>()
				.Execute("user1@email.com");

			Console.WriteLine("User by e-mail \"user1@email.com\":");
			Console.WriteLine("{0} {1} {2} {3}", user.Id, user.LastName, user.FirstName, user.Email);

			Console.Read();
		}
	}
}