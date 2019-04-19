using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Data
{
    /// <summary>
    /// Представляет значения по умолчанию для первичной инциализации БД
    /// </summary>
    public static partial class ApplicationDataDefaults
    {
        /// <summary>
        /// Данные для наполнения БД при первичной инициализации
        /// </summary>
        public static string SqlServerDataSampleFilePath => "~/App_Data/Install/Data.Sample.sql";
    }
}
