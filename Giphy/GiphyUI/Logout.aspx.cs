using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiphyUI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Kills sessions and disposes of them
            Session.Abandon();
            Session.Clear();
            Session.Contents.RemoveAll();
            Session.RemoveAll();
            //Signs out formsauthentication
            System.Web.Security.FormsAuthentication.SignOut();

            //Redirects to login page
            Response.Redirect("~/Login.aspx");
        }
    }
}