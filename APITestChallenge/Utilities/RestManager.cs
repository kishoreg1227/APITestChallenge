using APITestChallenge.DataModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace APITestChallenge.Utilities
{
    /// <summary>
    /// Rest Manager class
    /// </summary>
    public class RestManager
    {
        #region private variables

        private const string JSONFILEFOLDER = "Configurations";
        private const string JSONFILENAME = "AppSettings.json";
        private readonly IRestClient _restClient;
        private readonly AppSettings _appSettings;
        private readonly IRestRequest _restRequest;
        private string jsonBody;

        private List<KeyValuePair<string, object>> _queryStrings =
            new List<KeyValuePair<string, object>>();

        #endregion private variables

        public RestManager()
        {
            _appSettings = GetAppSettings();
            _restClient = new RestClient(_appSettings.BaseURL);
            _restRequest = new RestRequest();
            _restRequest.AddHeader("x-api-key", _appSettings.APIKey);
        }

        public string ResponseContent { get; private set; }

        public HttpStatusCode Status { get; private set; }

        public void AddHeaders(string name, string value)
        {
            _restRequest.AddHeader(name, value);
        }

        public void AddJsonBody(string body)
        {
            jsonBody = body;
        }

        public void AddParameter(string key, string value)
        {
            _restRequest.AddParameter(key, value);
        }

        public void AddQueryStrings(string key, object value)
        {
            var _queryString = new KeyValuePair<string, object>(key, value);
            _queryStrings.Add(_queryString);
        }

        public void AddQueryStrings(List<KeyValuePair<string, object>> queryStrings)
        {
            _queryStrings = queryStrings;
        }

        public string BuildQueryString()
        {
            var builder = new StringBuilder("?");

            if (_queryStrings != null)
            {
                for (int index = 0; index < _queryStrings.Count; index++)
                {
                    builder.Append(_queryStrings[index].Key);
                    builder.Append("=");
                    builder.Append(_queryStrings[index].Value);
                    builder.Append("&");
                }
            }
            else
            {
                Console.WriteLine("No query strings are specified to hit the API");
            }
            builder.Remove(builder.Length - 1, 1); // Remove the last '&' or the '?' if no query strings exist in the _queryString list.

            return builder.ToString();
        }

        public void ExecuteRequest(string uri, Method verb)
        {
            _restRequest.Resource = uri + BuildQueryString();
            _restRequest.Method = verb;

            try
            {
                if ((verb == Method.POST)
                    || (verb == Method.PUT)
                    || (verb == Method.DELETE))
                {
                    _restRequest.AddJsonBody(jsonBody);
                }
                var response = _restClient.Execute(_restRequest);
                ResponseContent = response.Content;
                Status = response.StatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        #region private methods

        private AppSettings GetAppSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
            var appSettings = JsonConvert.DeserializeObject<AppSettings>(LoadJsonData(), settings);
            return appSettings;
        }

        private string LoadJsonData()
        {
            string jsonString = string.Empty;
            using (StreamReader r = new StreamReader(GetTheJsonFilePath()))
            {
                jsonString = r.ReadToEnd();
            }
            return jsonString;
        }

        private string GetTheJsonFilePath()
        {
            DirectoryInfo currentDirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            return Path.Combine(currentDirInfo.FullName, JSONFILEFOLDER, JSONFILENAME);
        }

        #endregion private methods
    }
}