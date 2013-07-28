using System.Data.Entity;
using DataModel.Domain;

namespace EFDataAccess
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(string connectionString)
			: base(connectionString)
		{
		}

		public virtual IDbSet<User> Users
		{
			get { return Set<User>(); }
		}
	}
}