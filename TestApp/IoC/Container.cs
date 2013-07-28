﻿using System;
using Ninject;

namespace TestApp.IoC
{
	public class Container
	{
		private static readonly Container _current = new Container();
		private StandardKernel _container;

		private Container()
		{
		}

		public static Container Current
		{
			get { return _current; }
		}

		private void Configure()
		{
			lock (_current)
			{
				_container = new StandardKernel(new Configuration());
			}
		}

		public T Resolve<T>()
		{
			if (_container == null)
				Configure();

			return _container.Get<T>();
		}

		public object Resolve(Type type)
		{
			if (_container == null)
				Configure();

			return _container.Get(type);
		}
	}
}