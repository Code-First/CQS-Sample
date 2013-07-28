using System;
using System.Collections.Generic;
using System.Linq;

namespace DataModel.Core
{
	public class CommandFactory : ICommandsFactory
	{
		private readonly Func<Type, object[]> _resolveCallback;

		public CommandFactory(Func<Type, object[]> resolveCallback)
		{
			_resolveCallback = resolveCallback;
		}

		public void ExecuteQuery<T>(T command)
			where T : class, ICommand
		{
			// Initialize context
			IEnumerable<ICommandHandler<T>> commandHandlers = 
				_resolveCallback(typeof (ICommandHandler<T>))
				.OfType<ICommandHandler<T>>();

			if ((commandHandlers != null) && commandHandlers.Any())
			{
				foreach (ICommandHandler<T> commandHandler in commandHandlers)
				{
					// Execute command
					commandHandler.Execute(command);

					// Dispose context
					commandHandler.Dispose();
				}
			}
			else
				throw new ArgumentException("Unknown command \"" + typeof (T).FullName + "\"");
		}
	}
}