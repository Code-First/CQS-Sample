using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using Moq;

namespace UnitTests.Utils.EntityFramework
{
	public static class DbContextUtils
	{
		public static Mock<T> SetupDbContextData<T, TDbSet, TResult>(this Mock<T> dbContextMock,
			Expression<Func<T, TDbSet>> elementSelector, IEnumerable<TResult> result)
			where T : DbContext
			where TDbSet : class
			where TResult : class
		{
			dbContextMock.Setup(elementSelector).Returns(new DbSetMock<TResult>(result) as TDbSet);
			return dbContextMock;
		}

		public static T Build<T>(this Mock<T> dbContextMock)
			where T : DbContext
		{
			return dbContextMock.Object;
		}
	}
}