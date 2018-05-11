using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using GiphyAPI.Helpers;


namespace GiphyUI
{
    public class Global : HttpApplication
    {
        // Shared HttpClient 
        internal static HttpClient ServiceClient;

        //Key Values for services
        internal static string userServices = AppSetting("UsersServices");

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initializes HTTPClient
            InitializeServiceClient();
        }
        void InitializeServiceClient()
        {
            ServiceClient = new HttpClient();
            ServiceClient.DefaultRequestHeaders.ConnectionClose = false;
            ServiceClient.DefaultRequestHeaders.Clear();
        }
            //encrypt Method for a given string
            internal static string Encrypt(string toEncrypt)
        {
            return Crypto.EncryptText(toEncrypt, AppSetting("AESCBCKey"), AppSetting("AESCBCIV"));
        }
        /// <summary>
        /// AppSetting
        /// </summary>
        /// <param name="appSettingName">Config AppSetting Key</param>
        /// <returns>(string)AppSetting</returns>
        internal static string AppSetting(string appSettingName)
        {
            string appSetting = ConfigurationManager.AppSettings[appSettingName].ToString();

            return appSetting
                //Remove service based with configured addresses
                .Replace("{UsersServices}", userServices);
        } // AppSetting

        internal static string StripTags(string source)
        {
            source = source.Trim();
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        /// <summary>
        /// Helper function to MD5 hash a string 
        /// </summary>
        internal static string HashMD5(string toHash)
        {
            MD5 newHash = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = newHash.ComputeHash(Encoding.UTF8.GetBytes(toHash));

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString().ToUpper();
            // return SCP.Helpers.AESCBC.BytesToHex(data);
        }

        /// <summary>
        /// Application_End
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_End(object sender, EventArgs e)
        {
            // Dispose of shared HttpClient instances
            ServiceClient.CancelPendingRequests();
            ServiceClient.Dispose();
        }
    }
}