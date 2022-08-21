using System;
using System.Reflection;
using System.Collections.Generic;

namespace MVC.Utility
{
    public class DependencyInjection : Singleton<DependencyInjection>
    {
        private Dictionary<Type, object> _dependencies = new Dictionary<Type, object>();
        public void RegisterDependencies(Type type, object obj)
        {
            if (!_dependencies.ContainsKey(type))
            {
                _dependencies.Add(type, obj);
            }
        }

        public void UnregisterDependencies(Type type)
        {
            if (_dependencies.ContainsKey(type))
            {
                _dependencies.Remove(type);
            }
        }

        public void InjectDependencies(object targetObject)
        {
            InjectField(targetObject);
            InjectProperty(targetObject);
        }

        public void InjectField(object targetObject)
        {
            FieldInfo[] fields = targetObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                if (field.FieldType.IsClass || field.FieldType.IsInterface)
                {
                    object value;
                    if (_dependencies.TryGetValue(field.FieldType, out value))
                    {
                        field.SetValue(targetObject, value);
                    }
                }
            }
        }

        public void InjectProperty(object targetObject)
        {
            PropertyInfo[] properties = targetObject.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass || property.PropertyType.IsInterface)
                {
                    object value;
                    if (_dependencies.TryGetValue(property.PropertyType, out value))
                    {
                        property.SetValue(targetObject, value);
                    }
                }
            }
        }
    }
}
