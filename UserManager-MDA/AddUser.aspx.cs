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
        private string dni;
        private string password;
        private string repeatedPassword;
        private string name;
        private string surname;
        private string category;
        private string admin;
        private string information;
        private int dniNumber;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            fail.Visible = false;

        }

        public void FormSubmit(object sender, EventArgs e)
        {
            dni = DNIinput.Value;
            password = PasswordInput.Value;
            repeatedPassword = RepeatPasswordInput.Value;
            name = NameInput.Value;
            surname = SurNameInput.Value;
            category = CategorySelectInput.Value;
            var isAdmin = adminCheck.Checked;
            information = InformationTextarea.Value;

            if (isAdmin) admin = "Admin";
            else admin = "User";

            if (!CheckRequirements(dni, password, repeatedPassword, name, surname, category, admin, information)) return;
            AddUserToDataBase();
        }
        
        private void AddUserToDataBase()
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\UserManagerDB.db");
            var connstring = "data source=" + relativeRoute;

            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(getQuery(), db))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Response.Redirect("./Default");

                    }
                    catch
                    {
                        fail.InnerText = "Ya existe un usuario con este nombre";
                        fail.Visible = true;
                    }
                    
                    
                    db.Close();
                }
            }
        }
        
        
        protected string getQuery()
        {
            String s = getBase() + getValues();
            return s;
        }

        protected string getBase()
        {
            return "insert into Users (dni , password, name, surname, category, rol, information) values (";
        }

        protected string getValues()
        {
            return  + dniNumber + ",'" + password + "','" + name + "','" + surname + "','" + category + "','" + admin + "','" + information +
                   "')";
        }

      

        private bool CheckRequirements(string dni, string password, string repeatedPassword, string name, string surname, string category, string admin, string information)
        {
            
            if (name == "" || surname =="" || password == ""|| repeatedPassword == "" || category == "")
            {
                if (password != repeatedPassword)
                {
                    fail.InnerText = "Las contraseñas no coinciden";
                    fail.Visible = true;
                    return false;
                }
                fail.InnerText = "Faltan campos por rellenar";
                fail.Visible = true;
                return false;
            }

            if (CheckId(dni)) return true;
            
            fail.InnerText = "DNI erróneo";
            fail.Visible = true;
            return false;
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
                dniNumber = number;
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


  
        
    }
}