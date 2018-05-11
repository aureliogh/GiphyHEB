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
    public class User : ServiceRepository, IDisposable //Releasing unmanaged resources
    {
        #region Private Properties

        //Underlying DTOs
        private  DTO.User _user = new DTO.User();
        
    
        private Dictionary<int, DTO.Category> _category = new Dictionary<int, DTO.Category>();
        #endregion

        #region Constructors
        //Empty User constructor        
        public User(ref HttpClient httpClient) : base(ref httpClient)
        {

        }
        /// <summary>
        /// User by username constructor
        /// </summary>
        /// <param name="Username"></param>
        public User(string username, ref HttpClient httpClient) : base(ref httpClient)
        {
            try
            {
                var request = AppSetting("User.ByUsername")
                    .Replace("{username}", username);

                var result = Get(request, true);
                if (result.IsSuccessStatusCode) { ParseResult(result); }
            }
            catch (Exception ex) { ErrorHelper.Handle(ex); }
        }

        /// <summary>
        /// User by email address constructor
        /// </summary>
        /// <param name="email"></param>
        public User(MailAddress email, ref HttpClient httpClient) : base(ref httpClient)
        {
            try
            {
                var request = AppSetting("User.ByEmail")
                    .Replace("{email}", email.Address);

                var result = Get(request, true);
                if (result.IsSuccessStatusCode) { ParseResult(result); }
            }
            catch (Exception ex) { ErrorHelper.Handle(ex); }
        }

        #endregion

        #region Public Properties

        public override string ToString()
        {
            return _user.ToString();
        }

        public bool Exists
        {
            get { return _user.Exists; }
            
        }
        public int UserID
        {
            get { return _user.id_user.GetValueOrDefault(-1); }
        }
        public string Username
        {
            get { return _user.username; }
        }
        public string Password
        {
            get { return _user.password; }
            
        }
        public string Firstname
        {
            get { return _user.firstname; }
            
        }
        public string Lastname
        {
            get { return _user.lastname; }
            
        }
        public string Email
        {
            get { return _user.email; }
            
        }
        public DateTime? lastlogin
        {
            get { return _user.lastlogin; }
            set { _user.lastlogin = value; }
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
                    DTO.User[] userRtn = JsonConvert.DeserializeObject<DTO.User[]>(content);
                    if (userRtn.Length > 0)
                    { 

                        if (!_user.Exists)
                        {
                            _user = userRtn.First();
                        }
                        foreach (var eUser in userRtn)
                        {
                            var idUser = eUser.id_user.GetValueOrDefault(-1);                            
                        }
                    }
                }
            }
            catch (Exception ex) { ErrorHelper.Handle(ex); }
        }

        /// <summary>
        /// Updates user
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            try
            {
                var request = AppSetting("User.Update")
                        .Replace("{id}", UserID.ToString());

                var result = Put(request, _user);

                return (((int)result.StatusCode) == 200);
            }
            catch (Exception ex)
            {
                ErrorHelper.Handle(ex);
                return false;
            }
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
                        .Replace("{idUser}", _user.id_user.ToString());

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