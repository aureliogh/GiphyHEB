using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiphyAPI;
using GiphyAPI.Constructor;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GiphyUI
{
    public partial class NewUser : System.Web.UI.Page
    {
        public bool userExists; //Maintains status if user exists (username & Password)
        public bool userNameExists; //Maintains status if username already exists
        public bool userEmailExists; //Maintains status if email address already exists
        public int userId; //maintains userid that was just registered
        public bool userInserted; //Maintains status if user was successfully registered

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Checks to see if page is valid from all validators
            if (Page.IsValid)
            {
                ValidateUser();
                if (userExists)
                {
                    //User does exists. Display notification about existent user
                    lblMsg.Text = "It appears you are an existent user. Please try to login again.";
                }
                else
                {
                    if (userNameExists)
                    {
                        //Username does exists. Display notification about invalid user
                        lblMsg.Text = "User already taken. Please try a different one.";
                    }
                    else
                    {
                        if (userEmailExists)
                        {
                            //Email address exists.
                            lblMsg.Text = "Email address already in used. Please try to login.";
                        }
                        else
                        {
                            PostUserData();

                            if (userInserted)
                            {
                                //javascript popup confirmation for now
                                Response.Write("<script>alert('Successfully Registered');</script>");
                                Response.Redirect("Login.aspx");
                            }
                        }
                    }
                }

            }

        }


        // Validates if UserName and/or email exist
        protected void ValidateUser()
        {
            try
            {
                var nameUser = new User(txtUserName.Text.Trim(),ref Global.ServiceClient);
                var emailUser = new User(new MailAddress(txtEmail.Text.Trim()), ref Global.ServiceClient);

                userExists = (!nameUser.Exists && !emailUser.Exists) ? false : true;
                userNameExists = (!nameUser.Exists) ? false : true;
                userEmailExists = (!emailUser.Exists) ? false : true;
            }
            catch (Exception ex)
            {
                Trace.Write(ex.ToString());
            }
        }

        //Insert User Data
        protected void PostUserData()
        {
            try
            {
                //Fill up user class with data
                var user = new tbl_user();
                user.username = txtUserName.Text.ToString();
                var hashpassword = Global.HashMD5(txtPassword.Text.Trim());
                user.password = hashpassword;
                user.email = txtEmail.Text.ToString();
                user.firstname = txtFirstName.Text.ToString();
                user.lastname = txtLastName.Text.ToString();
                user.adddttm = DateTime.Now; // check server time if deployed to cloud Global.Now();
                user.lastlogin = DateTime.Now; // check server time if deployed to cloud Global.Now();

                string uriParams = Global.AppSetting("User.Add");
                var response = Global.ServiceClient.PostAsJsonAsync(uriParams, user).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var data = (JObject)JsonConvert.DeserializeObject(json);
                    userId = data["id_user"].Value<Int32>();
                    userInserted = true;
                }
                else
                {
                    Trace.Write("User was not registered");
                    userInserted = false;
                }
            }
            catch (Exception ex)
            {
                Trace.Write(ex.ToString());
            }

        }
    }
}