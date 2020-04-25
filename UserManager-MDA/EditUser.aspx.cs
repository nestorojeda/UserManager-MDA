using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManager_MDA
{
    public partial class EditUser : System.Web.UI.Page
    {
        byte[] img;
        string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            fail.Visible = false;
            var id = Request.QueryString["id"];
            userId = id;
            if (!IsPostBack)
            {
                fetchData(id);
            }
        }

        protected void fetchData(string id)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\UserManagerDB.db");
            var connstring = "data source=" + relativeRoute;

            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Users WHERE ID=" + id, db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if (reader.GetName(i).Equals("dni"))
                            {
                                DNIinput.Value = reader.GetInt32(i) + "";
                            }
                            else if (reader.GetName(i).Equals("password"))
                            {
                                PasswordInput.Value = reader.GetString(i);
                            }
                            else if (reader.GetName(i).Equals("name"))
                            {
                                NameInput.Value = reader.GetString(i);
                            }
                            else if (reader.GetName(i).Equals("surname"))
                            {
                                SurNameInput.Value = reader.GetString(i);
                            }
                            else if (reader.GetName(i).Equals("category"))
                            {
                                CategorySelectInput.Value = reader.GetString(i);
                            }
                            else if (reader.GetName(i).Equals("rol"))
                            {
                                if (reader.GetString(i).Equals("administrador"))
                                {
                                    adminCheck.Checked = true;
                                }

                            }
                            else if (reader.GetName(i).Equals("information"))
                            {
                                InformationTextarea.Value = reader.GetString(i);
                            }
                            
                        }
                    }
                }
                cmd = new SQLiteCommand("SELECT image FROM Users WHERE ID=" + id, db);
                try
                {
                    byte[] bytesImage = (byte[])cmd.ExecuteScalar();
                    img = bytesImage;
                    previewImage.ImageUrl = "data:image;base64," + Convert.ToBase64String(bytesImage);
                }
                catch
                {

                }
                db.Close();
            }
        }

        protected Boolean checkValues()
        {
            if (!DNIinput.Value.Equals("") && !PasswordInput.Value.Equals("") && !NameInput.Value.Equals("") && !SurNameInput.Value.Equals("") && !CategorySelectInput.Value.Equals(""))
            {
                return true;
            }
            return false;
        }

        protected void updateImage(object sender, EventArgs e)
        {
            Stream fs = flImage.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            img = bytes;
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            previewImage.ImageUrl = "data:image/png;base64," + base64String;
        }

        protected void modifyUser(object sender, EventArgs e)
        {
            if (checkValues())
            {
                AddUserToDataBase(userId);
            }
            else
            {
                fail.InnerText = "Rellene los campos obligatorios";
                fail.Visible = true;
            }
        }

        private void AddUserToDataBase(string id)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\UserManagerDB.db");
            var connstring = "data source=" + relativeRoute;

            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                if (flImage.HasFile)
                {
                    var cmd = new SQLiteCommand("UPDATE Users Set dni = @Dni, password = @Password, name = @Name, surname = @Surname, category = @Category, rol = @Rol, information = @Information, image = @Image WHERE ID=" + id, db);
                    try
                    {
                        cmd.Parameters.Add("@Dni", DbType.Int32).Value = DNIinput.Value;
                        cmd.Parameters.Add("@Password", DbType.String).Value = PasswordInput.Value;
                        cmd.Parameters.Add("@Name", DbType.String).Value = NameInput.Value;
                        cmd.Parameters.Add("@Surname", DbType.String).Value = SurNameInput.Value;
                        cmd.Parameters.Add("@Category", DbType.String).Value = CategorySelectInput.Value;
                        if (adminCheck.Checked)
                        {
                            cmd.Parameters.Add("Rol", DbType.String).Value = "administrador";
                        }
                        else
                        {
                            cmd.Parameters.Add("@Rol", DbType.String).Value = "usuario";
                        }
                        cmd.Parameters.Add("@Information", DbType.String).Value = InformationTextarea.Value;
                        Stream fs = flImage.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        cmd.Parameters.Add("@Image", DbType.Binary).Value = bytes;
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
                else {
                    var cmd = new SQLiteCommand("UPDATE Users Set dni = @Dni, password = @Password, name = @Name, surname = @Surname, category = @Category, rol = @Rol, information = @Information WHERE ID=" + id, db);

 
                    try
                    {
                        cmd.Parameters.Add("@Dni", DbType.Int32).Value = DNIinput.Value;
                        cmd.Parameters.Add("@Password", DbType.String).Value = PasswordInput.Value;
                        cmd.Parameters.Add("@Name", DbType.String).Value = NameInput.Value;
                        cmd.Parameters.Add("@Surname", DbType.String).Value = SurNameInput.Value;
                        cmd.Parameters.Add("@Category", DbType.String).Value = CategorySelectInput.Value;
                        if (adminCheck.Checked)
                        {
                            cmd.Parameters.Add("Rol", DbType.String).Value = "administrador";
                        }
                        else
                        {
                            cmd.Parameters.Add("@Rol", DbType.String).Value = "usuario";
                        }
                        cmd.Parameters.Add("@Information", DbType.String).Value = InformationTextarea.Value;
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }

                db.Close();
                string url = "~/UserList.aspx";
                Response.Redirect(url);
            }
        }

        private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,
            ImageFormat formatOfImage)
        {
            byte[] Ret;
            using (var ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
            return Ret;
        }
    }
}