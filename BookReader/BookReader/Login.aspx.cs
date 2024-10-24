using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

// using disconnected apporoach for login
namespace BookReader
{
    public partial class Login : System.Web.UI.Page
    {
        DataSet ds;
        SqlConnection con;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        { 
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "admin" && password == "admin")
            {
                txtPassword.Text = "";
                FormsAuthentication.SetAuthCookie(username, false);
                Response.Redirect("http://localhost:49782/AdminHome.aspx");
            }
            else
            {
                Boolean isUser = false;
                con = new SqlConnection();
                con.ConnectionString = WebConfigurationManager.ConnectionStrings["conDB"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Users";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                try
                {
                    using (con)
                    {
                        con.Open();
                        da.Fill(ds, "Users");
                    }
                    foreach (DataRow dr in ds.Tables["Users"].Rows)
                    {
                        if (dr[ds.Tables["Users"].Columns["username"]].ToString() == username && dr[ds.Tables["Users"].Columns["password"]].ToString() == password)
                        {
                            isUser = true;
                        }
                    }
                    if (isUser)
                    {

                        txtPassword.Text = "";
                        FormsAuthentication.SetAuthCookie(username, false);
                        Response.Redirect("http://localhost:49782/Homepage.aspx");
                    }
                    else
                    {
                        txtPassword.Text = "";
                        Response.Write("<script>alert('Invlaid Username/Password');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
                //GVUsers.DataSource = ds.Tables["Users"];
                //GVUsers.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Signup.aspx");
        }
    }
}