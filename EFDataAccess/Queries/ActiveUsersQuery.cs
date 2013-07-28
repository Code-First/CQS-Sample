using System.Collections.Generic;
using System.Linq;
using DataModel.Domain;
using DataModel.Queries;
using EFDataAccess.Core;

namespace EFDataAccess.Queries
{
	public class ActiveUsersQuery : EFQueryBase<ApplicationDbContext>, IActiveUsersQuery
	{
		public ActiveUsersQuery(ApplicationDbContext context)
			: base(context)
		{
		}

		public IEnumerable<User> Execute()
		{
			return DbContext
				.Users
				.Where(x => x.IsActive)
				.ToArray();
		}
	}
}