using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManager_MDA
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] != null)
            {
                if(Session["rol"].Equals("administrador"))
                {
                    Response.Redirect("~/UserList.aspx");
                }
                else
                {
                    userNotLoggedMessage.Visible = false;
                    userNotAdminMessage.Visible = true;
                }
            }
            else
            {
                userNotLoggedMessage.Visible = true;
                userNotAdminMessage.Visible = false;
            }
        }
    }
}