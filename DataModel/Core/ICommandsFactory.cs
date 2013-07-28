namespace DataModel.Core
{
	public interface ICommandsFactory
	{
		void ExecuteQuery<T>(T command)
			where T : class, ICommand;
	}
}