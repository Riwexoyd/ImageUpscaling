﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageUpscaling.Helpers
{
    public static class ReflectionHelper
    {
        public static ICollection<T> GetInstance<T>()
        {
            var type = typeof(T);
            var types = GetImplimentationTypes(type).Where(i => !i.IsAbstract && !i.IsInterface);
            return types.Select(i => (T)Activator.CreateInstance(i)).ToList();
        }

        public static ICollection<Type> GetImplimentationTypes(Type type)
        {
            return Assembly.GetAssembly(type).GetTypes()
                .Where(i => type.IsAssignableFrom(i) && i != type).ToList();
        }
    }
}
