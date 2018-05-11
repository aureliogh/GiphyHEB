using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GiphyAPI;

namespace GiphyUI.Portal
{
    public partial class SiteAuthenticated : System.Web.UI.MasterPage
    {
        private GiphyAPI.DTO.User _user;


        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["User_LoggedIn"] == null)
            {
                Server.ClearError();
                Response.Redirect("~/Login.aspx", true);
                Context.ApplicationInstance.CompleteRequest();

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}