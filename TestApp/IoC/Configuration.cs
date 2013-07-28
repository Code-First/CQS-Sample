using DataModel.Commands;
using DataModel.Core;
using DataModel.Queries;
using EFDataAccess;
using EFDataAccess.Commands;
using EFDataAccess.Queries;
using Ninject.Modules;
using TestApp.Commands;

namespace TestApp.IoC
{
	public class Configuration : NinjectModule
	{
		public override void Load()
		{
			// Infrastructure
			Bind<IQueryFactory>().ToMethod(t => new QueryFactory(x => Container.Current.Resolve(x))).InTransientScope();
			Bind<ICommandsFactory>()
				.ToMethod(t => new CommandFactory(x => (object[]) Container.Current.ResolveAll(x)))
				.InTransientScope();

			// DbContext
			Bind<ApplicationDbContext>().ToSelf().WithConstructorArgument("connectionString", "MyContext");

			// Queries
			Bind<IActiveUsersQuery>().To<ActiveUsersQuery>().InTransientScope();
			Bind<IInactiveUsersQuery>().To<InactiveUsersQuery>().InTransientScope();
			Bind<IUserByEmailQuery>().To<UserByEmailQuery>().InTransientScope();

			// Commands
			Bind<ICommandHandler<CreateUserCommand>>().To<CreateUserCommandHandler>().InTransientScope();
			Bind<ICommandHandler<CreateUserCommand>>().To<CreateUserNotificationCommandHandler>().InTransientScope();
		}
	}
}