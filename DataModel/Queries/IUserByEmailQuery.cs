using DataModel.Core;
using DataModel.Domain;

namespace DataModel.Queries
{
	public interface IUserByEmailQuery : IQuery
	{
		User Execute(string email);
	}
}