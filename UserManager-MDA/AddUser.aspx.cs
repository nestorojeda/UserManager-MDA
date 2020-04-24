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


        public void FormSubmit(object sender, EventArgs e)
        {
            string dni = DNIinput.Value;
            string password = PasswordInput.Value;
            string repeatedPassword = RepeatPasswordInput.Value;
            string name = NameInput.Value;
            string surname = SurNameInput.Value;
            string category = CategorySelectInput.Value;
            string admin = adminCheck.Value;

            if (checkRequirements(dni, password, repeatedPassword, name,surname, category,admin))
            {
                AddUserToDataBase(name, surname, dni,password, category, admin );
                
            }
            else
            {
                //Error de que los passwords no coinciden
            }
        }

        private bool checkRequirements(string dni, string password, string repeatedPassword, string name, string surname, string category, string admin)
        {
            
            if (name == "" || surname =="" || password == ""|| repeatedPassword == "" || category == "" || admin == "" )
            {
                fail.InnerText = "Faltan campos por rellenar";
                fail.Visible = true;
                return false;
            }

            if (CheckId(dni))
            {
                fail.InnerText = "DNI erróneo";
                fail.Visible = true;
                return false;
            }

          

            return true;
        }

        private bool CheckId(string id)
        {
            if (id == String.Empty)
                return false;
            try
            {
                var letter = id.Substring(id.Length - 1, 1);
                id = id.Substring(0, id.Length - 1);
                var number = int.Parse(id);
                var rem = number % 23;
                var tmp = getLetter(rem);
                if (tmp.ToLower() != letter.ToLower())
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        
        private string getLetter(int id)
        {
            Dictionary<int, String> letter = new Dictionary<int, string>
            {
                {0, "T"},
                {1, "R"},
                {2, "W"},
                {3, "A"},
                {4, "G"},
                {5, "M"},
                {6, "Y"},
                {7, "F"},
                {8, "P"},
                {9, "D"},
                {10, "X"},
                {11, "B"},
                {12, "N"},
                {13, "J"},
                {14, "Z"},
                {15, "S"},
                {16, "Q"},
                {17, "V"},
                {18, "H"},
                {19, "L"},
                {20, "C"},
                {21, "K"},
                {22, "E"}
            };
            return letter[id];
        }

        private void AddUserToDataBase(string name, string secondName, string id, string password, string category, string isAdministrator)
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