using DataModel.Core;
using DataModel.Queries;
using EFDataAccess;
using EFDataAccess.Queries;
using Ninject.Modules;

namespace TestApp.IoC
{
	public class Configuration : NinjectModule
	{
		public override void Load()
		{
			Bind<IQueryFactory>().ToMethod(t => new QueryFactory(x => Container.Current.Resolve(x))).InTransientScope();

			Bind<ApplicationDbContext>().ToSelf().WithConstructorArgument("connectionString", "MyContext");

			Bind<IActiveUsersQuery>().To<ActiveUsersQuery>().InTransientScope();
			Bind<IUserByEmailQuery>().To<UserByEmailQuery>().InTransientScope();
		}
	}
}