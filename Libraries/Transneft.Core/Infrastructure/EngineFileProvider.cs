using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Transneft.Core.Infrastructure
{
    public class EngineFileProvider: IEngineFileProvider
    {
        #region Methods

        /// <summary>
        /// Объединяет массив строк в путь
        /// </summary>
        /// <param name="paths">Массив частей пути</param>
        /// <returns>Комбинированный путь</returns>
        public virtual string Combine(params string[] paths)
        {
            var path = System.IO.Path.Combine(paths.SelectMany(p => p.Split('\\', '/')).ToArray());

            if (path.Contains('/'))
                path = "/" + path;

            return path;
        }

        /// <summary>
        /// Сопоставляет виртуальный путь c физическим.
        /// </summary>
        /// <param name="path">Путь. Например: "~/bin"</param>
        /// <returns>Физический путь. Например: "c:\inetpub\wwwroot\bin"</returns>
        public virtual string MapPath(string path)
        {
            path = path.Replace("~/", string.Empty).TrimStart('/');
            return Combine(BaseDirectory ?? string.Empty, path);
        }

        #endregion

        protected string BaseDirectory { get; }
    }
}
