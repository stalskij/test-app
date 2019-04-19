using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Transneft.Core.Data
{
    /// <summary>
    /// Представляет поставщика данных
    /// </summary>
    public partial interface IDataProvider
    {
        #region Methods

        /// <summary>
        /// Инициализация БД
        /// </summary>
        void InitializeDatabase();

        /// <summary>
        /// Получить объект параметра базы данных (используется в процедурах)
        /// </summary>
        /// <returns>Parameter</returns>
        DbParameter GetParameter();

        #endregion

        #region Properties

        /// <summary>
        /// Возвращает значение, указывающее, поддерживает ли этот поставщик данных резервное копирование
        /// </summary>
        bool BackupSupported { get; }

        /// <summary>
        /// Возвращает максимальную длину данных для функций HASHBYTES. Возвращает 0, если функция HASHBYTES не поддерживается
        /// </summary>
        int SupportedLengthOfBinaryHash { get; }

        #endregion
    }
}
