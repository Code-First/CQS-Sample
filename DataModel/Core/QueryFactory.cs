using System;

namespace DataModel.Core
{
	public class QueryFactory : IQueryFactory
	{
		private readonly Func<Type, object> _resolveCallback;

		public QueryFactory(Func<Type, object> resolveCallback)
		{
			_resolveCallback = resolveCallback;
		}

		public T ResolveQuery<T>()
			where T : class, IQuery
		{
			return _resolveCallback(typeof (T)) as T;
		}
	}
}