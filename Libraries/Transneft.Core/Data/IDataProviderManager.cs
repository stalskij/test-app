using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Core.Data
{
    public interface IDataProviderManager
    {
        #region Properties

        /// <summary>
        /// Gets data provider
        /// </summary>
        IDataProvider DataProvider { get; }

        #endregion
    }
}
