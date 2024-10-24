using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookReader
{
    public partial class Uploadbook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx"); // Redirect to login if not authenticated
            }
            else if (!User.Identity.Name.Equals("admin"))
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    lblMessage.Visible = false;
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string description = txtDescription.Text;
            HttpPostedFile cover = coverPage.PostedFile;  
            HttpPostedFile book = bookPDf.PostedFile;
            string location = "Books/";
            string pathstring = Path.Combine(location, (title+".pdf"));   // to save pdf in separate folder

            //check both uploaded document have proper exptensions or not
            if (Path.GetExtension(Path.GetFileName(cover.FileName)).ToLower() == ".jpg" ||
                Path.GetExtension(Path.GetFileName(cover.FileName)).ToLower() == ".png")
            {
                if(cover.ContentLength<100000000)
                {
                    if (Path.GetExtension(Path.GetFileName(book.FileName)).ToLower() == ".pdf")
                    {
                        Stream stream = cover.InputStream; // this is to convert the image to bytes data and store it in database 
                        BinaryReader br = new BinaryReader(stream);
                        byte[] bytes = br.ReadBytes((int)stream.Length);

                        bookPDf.SaveAs(MapPath(pathstring));  // this saves pdf files uploaded to Books folder

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = WebConfigurationManager.ConnectionStrings["conDB"].ConnectionString;
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into Books (Title,Author,Description,Coverpage,filelocation) values (@var1, @var2, @var3, @var4, @var5)";
                        cmd.Parameters.AddWithValue("@var1", title);
                        cmd.Parameters.AddWithValue("@var2", author);
                        cmd.Parameters.AddWithValue("@var3", description);
                        cmd.Parameters.AddWithValue("@var4", bytes);
                        cmd.Parameters.AddWithValue("@var5", pathstring);


                        try
                        {
                            using (con)
                            {
                                con.Open();
                                int row = cmd.ExecuteNonQuery();
                                if (row > 0)
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "Book added successfullt Successfully";
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    txtTitle.Text = "";
                                    txtAuthor.Text = "";
                                    txtDescription.Text = "";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Only Books (.pdf) are allowed";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "File size should be less than 4mb";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Only images (.jpg, .png) are allowed";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:49782/AdminHome.aspx");
        }
    }
}