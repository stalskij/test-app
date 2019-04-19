using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Core.Infrastructure
{
    /// <summary>
    /// Предоставляет доступ ко всем "одиночкам" <see cref="Singleton{T}"/>.
    /// </summary>
    public class SingletonBase
    {
        static SingletonBase()
        {
            AllSingletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Словарь типов для экземпляров "одиночек".
        /// </summary>
        public static IDictionary<Type, object> AllSingletons { get; }
    }
}
