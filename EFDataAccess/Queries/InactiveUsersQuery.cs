using System.Collections.Generic;
using System.Linq;
using DataModel.Domain;
using DataModel.Queries;
using EFDataAccess.Core;

namespace EFDataAccess.Queries
{
	public class InactiveUsersQuery : EFQueryBase<ApplicationDbContext>, IInactiveUsersQuery
	{
		public InactiveUsersQuery(ApplicationDbContext dbContext)
			: base(dbContext)
		{
		}

		public IEnumerable<User> Execute()
		{
			return DbContext
				.Users
				.Where(x => x.IsActive == false)
				.ToArray();
		}
	}
}