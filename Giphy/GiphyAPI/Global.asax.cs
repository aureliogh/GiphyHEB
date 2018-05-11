using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GiphyAPI.Helpers;

namespace GiphyAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //HTTP Configurations Setups
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        //encrypt Method for a given string
        internal static string Encrypt(string toEncrypt)
        {
            return Crypto.EncryptText(toEncrypt, AppSetting("AESCBCKey"), AppSetting("AESCBCIV"));
        }

        //DEcrypt Method for a given string
        internal static string Decrypt(string toDecrypt)
        {
            return Crypto.DecryptText(toDecrypt, AppSetting("AESCBCKey"), AppSetting("AESCBCIV"));
        }

        /// <summary>
        /// AppSetting
        /// </summary>
        /// <param name="appSettingName">Config AppSetting Key</param>
        /// <returns>(string)AppSetting</returns>
        internal static string AppSetting(string appSettingName)
        {
            return ConfigurationManager.AppSettings[appSettingName].ToString();
        } // AppSetting

        /// <summary>
        /// Remove HTML/script tags from string using char array
        /// </summary>
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
    }
}
