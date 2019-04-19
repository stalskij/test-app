using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Core.Infrastructure
{
    /// <summary>
    /// "Одиночка". Гарантирует, что экземпляр объекта будет создан один раз
    /// на протяжении жизненного цикла приложения.
    /// </summary>
    /// <typeparam name="T">Тип объекта для хранения.</typeparam>
    /// <remarks>Доступ к экземпляру не синхронизирован.</remarks>
    public class Singleton<T> : SingletonBase
    {
        private static T instance;

        /// <summary>
        /// Экземпляр "одиночки" для указанного типа T. Только один экземпляр объекта будет создан для каждого типа.
        /// </summary>
        public static T Instance
        {
            get => instance;
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }
}
