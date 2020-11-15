using System;
using System.Collections.Generic;
using BsButtonAsp.Models;
using IO.Swagger.Client;
using Newtonsoft.Json;
using RestSharp;

namespace BsButtonAsp.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBsApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BsCreateViewModel GetBsItem(int? id);
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        List<BsCreateViewModel> GetUnverifiedBsItemList();
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>BsCreateViewModel</returns>
        BsCreateViewModel Post(BsCreateViewModel body);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BsApi : IBsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public BsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BsApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BsCreateViewModel GetBsItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling GetBsItem");

            var path = "/api/v1/Bs/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling GetBsItem: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling GetBsItem: " + response.ErrorMessage, response.ErrorMessage);

            var result = JsonConvert.DeserializeObject<BsCreateViewModel>(response.Content);
            return result;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public List<BsCreateViewModel> GetUnverifiedBsItemList()
        {

            var path = "/api/v1/Bs";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling GetUnverifiedBsItemList: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling GetUnverifiedBsItemList: " + response.ErrorMessage, response.ErrorMessage);

            var result = JsonConvert.DeserializeObject<List<BsCreateViewModel>>(response.Content);
            return result;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>BsCreateViewModel</returns>
        public BsCreateViewModel Post(BsCreateViewModel body)
        {

            var path = "/api/v1/Bs";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling Post: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling Post: " + response.ErrorMessage, response.ErrorMessage);

            return (BsCreateViewModel)ApiClient.Deserialize(response.Content, typeof(BsCreateViewModel), response.Headers);
        }

    }
}
