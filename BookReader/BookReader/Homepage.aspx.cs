using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Diagnostics;
using System.Web.Security;

namespace BookReader
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx"); // Redirect to login if not authenticated
            }
        }

        protected void ReadBook_click(object sender, EventArgs e)
        {
            //int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;  //get the index from which you have clicked read book button
            //string location = GridView1.Rows[rowIndex].Cells[1].Text;  //get the book name from column index 1
            //string filepath = Server.MapPath("~/Books/"+location+".pdf"); //give proper path to open pdf
            string location = "";
            int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;  //get the index from which you have clicked read book button
            string title = GridView1.Rows[rowIndex].Cells[1].Text;  //get the book name from column index 1
            //Debug.WriteLine(id);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["conDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Books where title = '"+ title +"';";
            //Debug.WriteLine(cmd.CommandText);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                Object value = rdr["Filelocation"];
                location = value.ToString();
                //Debug.WriteLine(location);
            }
            con.Close();
            string filepath = Server.MapPath("~/" + location);
            WebClient user = new WebClient();
            Byte[] filebuffer = user.DownloadData(filepath);

            if (filebuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", filebuffer.Length.ToString());
                Response.BinaryWrite(filebuffer);
            }
        }

        

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string title = txtTitleSearch.Text;
            try
            {
                SqlConnection con = new SqlConnection();
                //Debug.WriteLine(title);
                con.ConnectionString = WebConfigurationManager.ConnectionStrings["conDB"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Books where Title = '" + title + "'; ";
                using (con)
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if(rdr.HasRows)
                    {
                        Label1.Visible = false;
                        GVSearch.DataSource = rdr;
                        GVSearch.DataBind();
                    }
                    else
                    {
                        GVSearch.DataSource = rdr;
                        GVSearch.DataBind();
                        Label1.Visible = true;
                        Label1.Text = "Book not found";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");

        }
    }
}