using System.Linq;
using DataModel.Domain;
using DataModel.Queries;
using EFDataAccess.Core;

namespace EFDataAccess.Queries
{
	public class UserByEmailQuery : EFQueryBase<ApplicationDbContext>, IUserByEmailQuery
	{
		public UserByEmailQuery(ApplicationDbContext context)
			: base(context)
		{
		}

		public User Execute(string email)
		{
			return DbContext
				.Users
				.SingleOrDefault(x => x.Email == email);
		}
	}
}