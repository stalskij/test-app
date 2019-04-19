using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Transneft.Core.Infrastructure;

namespace Transneft.Api.Infrastructure
{
    public class EngineContext
    {
        #region Methods

        /// <summary>
        /// Создать статический экземпляр движка.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            //создать жкземпляр движка
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new Engine());
        }

        /// <summary>
        /// Устанавливает статический экземпляр движка для предоставленного движка. Используйте этот метод для предоставления собственной реализации движка.
        /// </summary>
        /// <param name="engine">Движок</param>
        /// <remarks>Используйте этот метод, только если вы знаете, что делаете.</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Получает "одиночку" движка, используемый для доступа к сервисам.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }

        #endregion

    }
}
