using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTests.Utils.EntityFramework
{
	public class DbSetMock<T> : IDbSet<T>
		where T : class
	{
		private readonly HashSet<T> _data;
		private readonly IQueryable _query;

		public DbSetMock(IEnumerable<T> data)
		{
			_data = new HashSet<T>(data);
			_query = _data.AsQueryable();
		}

		public T Add(T entity)
		{
			_data.Add(entity);
			return entity;
		}

		public T Attach(T entity)
		{
			_data.Add(entity);
			return entity;
		}

		T IDbSet<T>.Create()
		{
			return Activator.CreateInstance<T>();
		}

		public TDerivedEntity Create<TDerivedEntity>()
			where TDerivedEntity : class, T
		{
			throw new NotImplementedException();
		}

		public virtual T Find(params object[] keyValues)
		{
			throw new NotImplementedException("Derive from DbSetMock and override Find");
		}

		public ObservableCollection<T> Local
		{
			get
			{
				return new
					ObservableCollection<T>(_data);
			}
		}

		public T Remove(T entity)
		{
			_data.Remove(entity);
			return entity;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		public Type ElementType
		{
			get { return _query.ElementType; }
		}

		public Expression Expression
		{
			get { return _query.Expression; }
		}

		public IQueryProvider Provider
		{
			get { return _query.Provider; }
		}
	}
}