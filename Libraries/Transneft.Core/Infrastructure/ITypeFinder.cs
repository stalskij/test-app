using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Transneft.Core.Infrastructure
{
    /// <summary>
    /// Классы, реализующие этот интерфейс, предоставляют информацию о типах 
    /// к различным сервисам движка.
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// Найти классы для типа
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="onlyConcreteClasses">Значение, указывающее, следует ли находить только конкретные классы</param>
        /// <returns>Результат</returns>
        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        /// <summary>
        /// Найти классы для типа
        /// </summary>
        /// <param name="assignTypeFrom">Тип</param>
        /// <param name="onlyConcreteClasses">Значение, указывающее, следует ли находить только конкретные классы</param>
        /// <returns>Результат</returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

        /// <summary>
        /// Найти классы для типа
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="assemblies">Сборки</param>
        /// <param name="onlyConcreteClasses">Значение, указывающее, следует ли находить только конкретные классы</param>
        /// <returns>Результат</returns>
        IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

        /// <summary>
        /// Найти классы для типа
        /// </summary>
        /// <param name="assignTypeFrom">Тип</param>
        /// <param name="assemblies">Сборки</param>
        /// <param name="onlyConcreteClasses">Значение, указывающее, следует ли находить только конкретные классы</param>
        /// <returns>Результат</returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

        /// <summary>
        /// Возвращает сборки, связанные с текущей реализацией.
        /// </summary>
        /// <returns>Список сборок</returns>
        IList<Assembly> GetAssemblies();
    }
}
