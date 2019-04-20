using System.Collections.Generic;
using Transneft.Web.Models.ConsumptionObjects;

namespace Transneft.Web.ViewModels
{
    /// <summary>
    /// Модель представления страницы создания новой точки измерения
    /// </summary>
    public class PowerPointCreateViewModel
    {
        /// <summary>
        /// Возвращает список объектов потребления
        /// </summary>
        public IList<ConsumptionObjectModel> ConsumptionObjects { get; set; }
    }
}
