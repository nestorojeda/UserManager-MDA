using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManager_MDA
{
    public partial class AddUser : System.Web.UI.Page
    {
        private string _dni;
        private string _password;
        private string _repeatedPassword;
        private string _name;
        private string _surname;
        private string _category;
        private string _information;
        private int _dniNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null || !Session["rol"].Equals("administrador"))
            {
                Response.Redirect("~/Default.aspx");
            }
            fail.Visible = false;

        }

        public void FormSubmit(object sender, EventArgs e)
        {
            _dni = DNIinput.Value;
            _password = PasswordInput.Value;
            _repeatedPassword = RepeatPasswordInput.Value;
            _name = NameInput.Value;
            _surname = SurNameInput.Value;
            _category = CategorySelectInput.Value;
            _information = InformationTextarea.Value;



            if (!CheckRequirements(_dni, _password, _repeatedPassword, _name, _surname, _category)) return;
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
                        cmd.Parameters.Add("@Dni", DbType.Int32).Value = _dniNumber;
                        cmd.Parameters.Add("@Password", DbType.String).Value = _password;
                        cmd.Parameters.Add("@Name", DbType.String).Value = _name;
                        cmd.Parameters.Add("@Surname", DbType.String).Value = _surname;
                        cmd.Parameters.Add("@Category", DbType.String).Value = _category;
                        if (adminCheck.Checked)
                        {
                            cmd.Parameters.Add("Rol", DbType.String).Value = "administrador";
                        }
                        else
                        {
                            cmd.Parameters.Add("@Rol", DbType.String).Value = "usuario";
                        }
                        cmd.Parameters.Add("@Information", DbType.String).Value = _information;
                        Stream fs = flImage.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        cmd.Parameters.Add("@Image", DbType.Binary).Value = bytes;
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
            String s = GetBase() + GetValues();
            return s;
        }

        private string GetBase()
        {
            return "insert into Users (dni , password, name, surname, category, rol, information, image) values (";
        }

        private string GetValues()
        {

            return "@dni" + "," + "@password" + "," + "@name" + "," + "@surname" + "," + "@category" + "," + "@rol" +
                   "," + "@information" + "," + "@image" + ")";
        }

      

        private bool CheckRequirements(string dni, string password, string repeatedPassword, string name, string surname, string category)
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
                _dniNumber = number;
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