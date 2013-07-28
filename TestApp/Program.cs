using System;
using System.Collections.Generic;
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
			var queryFactory = Container.Current.Resolve<IQueryFactory>();

			IEnumerable<User> activeUsers = queryFactory
				.ResolveQuery<IActiveUsersQuery>()
				.Execute();

			User user = queryFactory
				.ResolveQuery<IUserByEmailQuery>()
				.Execute("user1@email.com");

			Console.WriteLine("Active users: ");
			foreach (User t in activeUsers)
			{
				Console.WriteLine("{0} {1} {2} {3}", t.Id, t.LastName, t.FirstName, t.Email);
			}

			Console.WriteLine();
			Console.WriteLine("User by e-mail:");
			Console.WriteLine("{0} {1} {2} {3}", user.Id, user.LastName, user.FirstName, user.Email);

			Console.Read();
		}
	}
}