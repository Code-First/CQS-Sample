using System.Collections.Generic;
using DataModel.Core;
using DataModel.Domain;

namespace DataModel.Queries
{
	public interface IInactiveUsersQuery : IQuery
	{
		IEnumerable<User> Execute();
	}
}