using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiphyUI.Portal
{
    public partial class dashboard : System.Web.UI.Page
    {
        //public string GiphyUrl
        //{
        //    get { return Global.AjaxUrl("SearchGiphy", Request.IsSecureConnection); }
        //}
        //protected string GiphyKey
        //{
        //    get { return Global.AppSetting("GiphyAPIKey"); }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearchGiphy_Click(object sender, EventArgs e)
        {
            //var giphy = new Giphy(GiphyKey);
            //var searchParameter = new SearchParameter()
            //{
            //    Query = txtSearchGiphy.Text
            //};
            // Returns gif results
            //var gifResult = await giphy.GifSearch(searchParameter);

            //var stickerResult = await giphy.StickerSearch(searchParameter);
        }
    }
}