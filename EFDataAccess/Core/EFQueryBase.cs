using System.Data.Entity;
using DataModel.Core;

namespace EFDataAccess.Core
{
	public abstract class EFQueryBase<TContext> : IQuery
		where TContext : DbContext
	{
		protected readonly TContext DbContext;

		protected EFQueryBase(TContext dbContext)
		{
			DbContext = dbContext;
		}
	}
}