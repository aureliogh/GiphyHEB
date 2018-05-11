using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiphyAPI.Helpers;
using GiphyAPI.DTO;
using System.Net.Http;
using System.Net.Mail;
using Newtonsoft.Json;

namespace GiphyAPI.Constructor
{
    public class Category : ServiceRepository, IDisposable
    {
        #region Private Properties

        //Underlying DTOs
        private DTO.Category _category = new DTO.Category();

        #endregion

        #region Constructors
        //Empty Category constructor        
        public Category(ref HttpClient httpClient) : base(ref httpClient)
        {
        }
        /// <summary>
        /// User by username constructor
        /// </summary>
        /// <param name="idUser"></param>
        public Category(string idUser, ref HttpClient httpClient) : base(ref httpClient)
        {
            try
            {
                var request = AppSetting("Category.ByIdUser")
                    .Replace("{idUser}", idUser);

                var result = Get(request, true);
                if (result.IsSuccessStatusCode) { ParseResult(result); }
            }
            catch (Exception ex) { ErrorHelper.Handle(ex); }
        }

        

        #endregion

        #region Public Properties

        public override string ToString()
        {
            return _category.ToString();
        }

        public bool Exists
        {
            get { return _category.Exists; }

        }
        public int CategoryID
        {
            get { return _category.id_category.GetValueOrDefault(-1); }
        }
        public string CategoryName
        {
            get { return _category.categoryName; }
        }
        public string CategoryDesc
        {
            get { return _category.categoryDescription; }

        }
        public int CategorySorting
        {
            get { return _category.sorting; }

        }
        public int CategoryUserId
        {
            get { return _category.id_user; }

        }        
        public DateTime? addttm
        {
            get { return _category.adddttm; }
            set { _category.adddttm = value; }
        }


        #endregion

        #region Related Functions

        private void ParseResult(HttpResponseMessage result)
        {
            try
            {
                var content = result.Content.ReadAsStringAsync().Result;
                if (content != "null")
                {
                    DTO.Category[] categoryRtn = JsonConvert.DeserializeObject<DTO.Category[]>(content);
                    if (categoryRtn.Length > 0)
                    {

                        if (!_category.Exists)
                        {
                            _category = categoryRtn.First();
                        }
                        foreach (var eCategory in categoryRtn)
                        {
                            var idCategory = eCategory.id_category.GetValueOrDefault(-1);
                        }
                    }
                }
            }
            catch (Exception ex) { ErrorHelper.Handle(ex); }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public void RefreshCategories(bool recache = false)
        {
            try
            {
                if (Exists)
                {
                    var request = AppSetting("Category.ByIdUser")
                        .Replace("{idUser}", _category.id_user.ToString());

                    var result = Get(request, recache);

                    if (result.IsSuccessStatusCode)
                    {
                        ParseResult(result);
                    }
                }
            }
            catch (Exception ex) { ErrorHelper.Handle(ex); }
        } // RefreshCategories

        /// <summary>
        /// 
        /// </summary>        

        #endregion
        //Disposes on unmanaged resources
        public new void Dispose()
        {
            base.Dispose();
        }
    }
}