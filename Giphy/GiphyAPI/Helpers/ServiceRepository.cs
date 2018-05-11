using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;



namespace GiphyAPI.Helpers
{
    //Serialize class that cannot be inherited
    [Serializable]
    public class ServiceRepository : IDisposable //Releasing unmanaged resources
    {
        //Declares http client variable 
        internal HttpClient _httpClient;
        //Collection for the http response
        internal Dictionary<string, HttpResponseMessage> _cache = new Dictionary<string, HttpResponseMessage>();
        //Declares config variable to read config values
        private AppSettingsReader _config = new AppSettingsReader();

        //READ properties for http client
        internal HttpClient Client { get { return _httpClient; } }

        //declare variable to carry replacement values for app config API config keys
        private string searchGiphy;
        private string getGiphyById;
        private string userServices;

        //replaces webconfig url values keys
        public ServiceRepository(ref HttpClient httpClient)
        {
            _httpClient = httpClient;
            userServices = _config.GetValue("UsersServices", typeof(string)).ToString();
            //searchGiphy = _config.GetValue("SearchGiphy", typeof(string)).ToString();
            //getGiphyById = _config.GetValue("GetGiphyById", typeof(string)).ToString();
        }

        //Gets initial values from web.config keys
        internal string AppSetting(string appSetting)
        {
            return _config.GetValue(appSetting, typeof(string)).ToString()
                .Replace("{UsersServices}", userServices);
                //.Replace("{SearchGiphy}", searchGiphy)
                //.Replace("{GetGiphyById}", getGiphyById);
        }

        //internal httpresponse message for get method calls
        //with cached options in mind. This could be timed if needed.
        internal HttpResponseMessage Get(string request, bool recache = false)
        {
            //.net framework URI class to to handle relative URIs
            var key = Uri.EscapeUriString(request);
            //Validates to see if cached values are still existent. 
            //if not then calls async method to retrieve data again.
            if (!recache && _cache.ContainsKey(key))
            {
                //Cached value still good so retrieve value instead of calling
                return _cache[key] as HttpResponseMessage;
            }
            else
            {
                //Calls the api again to retrieve data
                HttpResponseMessage result = _httpClient.GetAsync(request).Result;

                _cache[key] = result;
                return result;
            }
        }

        //internal httpresponse message for put (Updates) method calls        
        internal HttpResponseMessage Put(string request, DTO.DataTransferObject dto)
        {
            HttpResponseMessage result = _httpClient.PutAsJsonAsync(request, dto).Result;

            return result;
        }

        //internal httpresponse message for post (inserts) method calls
        internal HttpResponseMessage Post(string request, DTO.DataTransferObject dto)
        {
            HttpResponseMessage result = _httpClient.PostAsJsonAsync(request, dto).Result;

            return result;
        }

        //Disposes of any unmanaged resources
        public void Dispose()
        {
            //Disposes of all objects
            _httpClient.CancelPendingRequests();
            _httpClient.Dispose();
            _cache.Clear();
            _config = null;
        }
    }
}