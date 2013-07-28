using System;

namespace DataModel.Core
{
	public interface ICommandHandler<in TCommand> : IDisposable
		where TCommand : ICommand
	{
		void Execute(TCommand command);
	}
}