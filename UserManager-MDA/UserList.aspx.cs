using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManager_MDA
{
    public partial class UserList : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            fetchData();
        }

        protected void fetchData()
        {
            DataTable dt = new DataTable();
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\UserManagerDB.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT[id], [dni], [password], [name], [surname], [category], [rol], [information] FROM[Users] ", db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
                GridViewData.DataSource = dt;
                GridViewData.DataBind();
            }
        }

        protected void GridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "EditUser")
            {
                LinkButton button = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                var id = GridViewData.DataKeys[row.RowIndex].Value.ToString();
                string url = "~/EditUser.aspx?id=" + id;
                Response.Redirect(url);
            } else if (e.CommandName == "DeleteUser")
            {
                LinkButton button = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                var id = GridViewData.DataKeys[row.RowIndex].Value.ToString();
                var relativeRoute = HttpContext.Current.Server.MapPath(@"\UserManagerDB.db");
                var connstring = "data source=" + relativeRoute;
                using (var db = new SQLiteConnection(connstring))
                {
                    db.Open();
                    SQLiteCommand cmd = new SQLiteCommand("delete from[Users] WHERE ID=" + id, db);
                    cmd.ExecuteReader();
                    db.Close();
                }
                fetchData();
            }

        }  
    }
}