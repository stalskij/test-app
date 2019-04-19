using System.Runtime.Serialization;

namespace Transneft.Core.Data
{
    /// <summary>
    /// Представляет перечисление типа поставщика данных
    /// </summary>
    public enum DataProviderType
    {
        /// <summary>
        /// Неизвестный
        /// </summary>
        [EnumMember(Value = "")]
        Unknown,

        /// <summary>
        /// MS SQL Server
        /// </summary>
        [EnumMember(Value = "sqlserver")]
        SqlServer
    }
}
