using System;
using System.Diagnostics;
using DataModel.Commands;
using DataModel.Core;

namespace TestApp.Commands
{
	public class CreateUserNotificationCommandHandler : ICommandHandler<CreateUserCommand>
	{
		public void Execute(CreateUserCommand command)
		{
			Debug.WriteLine("CreateUserNotificationCommandHandler executed");

			Console.WriteLine("		\"User created\" e-mail notifincation sent: ");
			Console.WriteLine("		{0} {1} {2} {3}", command.Id, command.FirstName, command.LastName, command.Email);
		}

		public void Dispose()
		{
		}
	}
}