using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Core.Infrastructure
{
    /// <summary>
    /// Абстракция поставщика файлов
    /// </summary>
    public interface IEngineFileProvider
    {
        /// <summary>
        /// Объединяет массив строк в путь
        /// </summary>
        /// <param name="paths">Массив частей пути</param>
        /// <returns>Комбинированный путь</returns>
        string Combine(params string[] paths);

        /// <summary>
        /// Сопоставляет виртуальный путь c физическим.
        /// </summary>
        /// <param name="path">Путь. Например: "~/bin"</param>
        /// <returns>Физический путь. Например: "c:\inetpub\wwwroot\bin"</returns>
        string MapPath(string path);
        
    }
}
