using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SQLite;

namespace UserManager_MDA
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] != null)
            {
                Response.Redirect("~/UserList.aspx");
            }
            fail.Visible = false;
        }

        protected void ValidateUser(object sender, EventArgs e)
        {
            var username = DNIinput.Value;
            var password = Passwordinput.Value; //Check Required
            Int32 id = 0;
            String rol = "";
            String inputPassword = "";

            var relativeRoute = HttpContext.Current.Server.MapPath(@"\UserManagerDB.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                var cmd = new SQLiteCommand("SELECT[id], [password], [rol] FROM[Users] WHERE [dni]=" + username, db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if (reader.GetName(i).Equals("id"))
                            {
                                id = reader.GetInt32(i);
                            }
                            if (reader.GetName(i).Equals("password"))
                            {
                                inputPassword = reader.GetString(i);   
                            }
                            if (reader.GetName(i).Equals("rol"))
                            {
                                rol = reader.GetString(i);
                            }
                        }
                    }
                }
            }
            if (password != inputPassword)
            {
                fail.InnerText = "La combinación de usuario y contraseña es incorrecta";
                fail.Visible = true;
            } else
            {
                Session["id"] = id;
                Session["rol"] = rol;
                if(rol == "administrador")
                {
                    Response.Redirect("~/UserList.aspx");
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}