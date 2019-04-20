using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace Transneft.Web.Framework.Managers
{
    /// <summary>
    /// Базовый менеджер доступа к данным
    /// </summary>
    public abstract class ManagerBase
    {
        #region Fields

        private IRestClient _client;

        #endregion

        #region Properties

        /// <summary>
        /// Возвращает адрес API
        /// </summary>
        public string Api { get; set; }

        #endregion


        #region Ctor

        public ManagerBase(string api)
        {
            this.Api = api;

            _client = new RestClient(api) { Proxy = SimpleWebProxy.Instance };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Оправить GET-запрос
        /// </summary>
        /// <typeparam name="T">Тип возвращаемых данных</typeparam>
        /// <returns>Модель данных</returns>
        public T Get<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            IRestResponse response = _client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Отправить POST-запрос с параметром
        /// </summary>
        public void Post(string url, object data)
        {

            var request = new RestRequest(url, Method.POST);
            request.AddParameter("value", JsonConvert.SerializeObject(data));

            IRestResponse response = _client.Execute(request);
        }

        #endregion
    }

    /// <summary>
    /// Прокси
    /// </summary>
    public class SimpleWebProxy : IWebProxy
    {
        public ICredentials Credentials { get; set; }
        private static SimpleWebProxy defaultProxy;

        #region Ctor

        public Uri GetProxy(Uri destination)
        {
            return destination;
        }

        #endregion

        #region Properties

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        public static SimpleWebProxy Instance
        {
            get
            {
                return defaultProxy ?? new SimpleWebProxy();
            }
        } 

        #endregion
    }
}
