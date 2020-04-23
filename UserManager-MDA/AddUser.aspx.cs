using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManager_MDA
{
    public partial class AddUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void AddUserToDataBase(string name, string secondName, string id, string password, string category, bool isAdministrator)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\UserManagerDB.db");
            var connstring = "data source=" + relativeRoute;

            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand("INSERT INTO Users(dni, password, name, surname, category, rol, information, image) VALUES (" +
                    id +","+
                    password+ "," +
                    name + "," +
                    secondName + "," +
                    category + "," +
                    isAdministrator.ToString()+ "," +
                    null + "," +
                    null+ ")" , db))
                {
                    db.Close();
                }
            }
        }
    }
}