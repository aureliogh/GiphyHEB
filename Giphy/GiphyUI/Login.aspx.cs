using GiphyAPI.Constructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiphyUI
{
    public partial class Login : System.Web.UI.Page
    {
        public bool userExists; //Maintains status if user authenticated
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
                    Response.Redirect("~/Portal/dashboard.aspx");
                }                
            }
        }
        protected void ValidateUser()
        {
            try
            {
                //Strips out invalid tags
                var cleanUser = Global.StripTags(txtUserName.Text.Trim());
                //Looks for user by username
                var nameUser = new User(cleanUser, ref Global.ServiceClient);
                //user valid check
                if (!nameUser.Exists)
                {
                    //user is no good
                    userExists = false;
                    lblMsg.Text = "Login Failed";
                }
                else
                {//valid user returned
                    //Hashes entered password
                    var pwdHash = Global.HashMD5(txtPassword.Text.Trim());

                    //validates password
                    if(nameUser.Password != pwdHash)
                    {
                        userExists = false;
                        lblMsg.Text = "Login Failed";
                    }
                    else
                    {
                        userExists = true;
                        //Sets last login date to current date
                        nameUser.lastlogin = DateTime.Now;
                        nameUser.Update();

                        //Initiates a session variable with username
                        Session.Add("User_LoggedIn", nameUser);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Trace.Write(ex.ToString());
            }
        }
    }
}