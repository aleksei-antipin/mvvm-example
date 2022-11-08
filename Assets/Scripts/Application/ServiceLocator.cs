using System;
using System.Collections.Generic;

namespace Test.Application
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;

        private readonly Dictionary<string, object> _keyInstances = new();

        private readonly Dictionary<Type, object> _typeInstances = new();

        #region Ctor

        private ServiceLocator()
        {
        }

        #endregion

        public static ServiceLocator Instance => _instance ??= new ServiceLocator();

        public void AddInstance<T>(T instance)
        {
            _typeInstances.TryAdd(typeof(T), instance);
        }

        public  T Resolve<T>()
        {
            if (_typeInstances.TryGetValue(typeof(T), out var instance))
                if (instance is T concreteInstance)
                    return concreteInstance;

            return default;
        }

        public  void AddInstance(string key, object value)
        {
            _keyInstances.TryAdd(key, value);
        }

        public  T Resolve<T>(string key)
        {
            if (_keyInstances.TryGetValue(key, out var instance))
                if (instance is T concreteInstance)
                    return concreteInstance;

            return default;
        }
    }
}