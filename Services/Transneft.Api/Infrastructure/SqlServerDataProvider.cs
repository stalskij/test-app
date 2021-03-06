﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Transneft.Core.Data;
using Transneft.Core.Domain.Common;
using Transneft.Data;
using Transneft.Data.Extensions;
using Transneft.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Transneft.Api.Infrastructure
{
    public partial class SqlServerDataProvider: IDataProvider
    {
        #region Methods

        /// <summary>
        /// Инициализация БД
        /// </summary>
        public virtual void InitializeDatabase()
        {
            var context = EngineContext.Current.Resolve<IDbContext>();

            //создание БД
            var createDb = (context as DbContext).Database.EnsureCreated();
             if (!createDb)
                return;

            var fileProvider = EngineContext.Current.Resolve<IEngineFileProvider>();

            //наполнение данными по умолчанию
            context.ExecuteSqlScriptFromFile(fileProvider.MapPath(ApplicationDataDefaults.SqlServerDataSampleFilePath));
        }

        /// <summary>
        /// Получить объект параметра базы данных (используется в процедурах)
        /// </summary>
        /// <returns>Параметр</returns>
        public virtual DbParameter GetParameter()
        {
            return new SqlParameter();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Возвращает значение, указывающее, поддерживает ли этот поставщик данных резервное копирование
        /// </summary>
        public virtual bool BackupSupported => true;

        /// <summary>
        /// Возвращает максимальную длину данных для функций HASHBYTES. Возвращает 0, если функция HASHBYTES не поддерживается
        /// </summary>
        public virtual int SupportedLengthOfBinaryHash => 8000; //для SQL Server 2008 и выше функция HASHBYTES имеет ограничение в 8000 символов.

        #endregion
    }
}
