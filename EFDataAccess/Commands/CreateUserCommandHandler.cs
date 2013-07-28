using System.Diagnostics;
using System.Linq;
using DataModel.Commands;
using DataModel.Core;
using DataModel.Domain;
using EFDataAccess.Core;

namespace EFDataAccess.Commands
{
	/// <summary>
	///     Create new inactive user
	/// </summary>
	public class CreateUserCommandHandler : EFCommandHandlerBase<CreateUserCommand, ApplicationDbContext>,
		ICommandHandler<CreateUserCommand>
	{
		public CreateUserCommandHandler(ApplicationDbContext dbContext)
			: base(dbContext)
		{
		}

		public override void Execute(CreateUserCommand command)
		{
			Debug.WriteLine("CreateUserCommandHandler executed");

			int id = DbContext.Users.Any() == false ? 1 : DbContext.Users.Max(x => x.Id) + 1;
			User user = new User
			{
				Id = id,
				FirstName = command.FirstName,
				LastName = command.LastName,
				Email = command.Email,
				IsActive = false
			};

			DbContext.Users.Add(user);
			DbContext.SaveChanges();

			command.Id = user.Id;
		}
	}
}