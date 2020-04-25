using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace UserManager_MDA
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null)
            {
                loginButton.Visible = true;
                logoutButton.Visible = false;
            } 
            else
            {
                loginButton.Visible = false;
                logoutButton.Visible = true;
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            Session["id"] = null;
            Session["rol"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}