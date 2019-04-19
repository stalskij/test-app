using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Core.Domain.Common
{
    /// <summary>
    /// Представляет класс-оболочку для строковых значений, используемых в качестве типа запроса
    /// </summary>
    public partial class StringQueryType
    {
        /// <summary>
        /// Возвращает или задает значение
        /// </summary>
        public string Value { get; set; }
    }
}
