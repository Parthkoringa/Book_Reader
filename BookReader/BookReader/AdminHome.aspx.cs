using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Diagnostics;
using System.Web.Security;

namespace BookReader
{
    public partial class AdminHome : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx"); // Redirect to login if not authenticated
            }
            else if(!User.Identity.Name.Equals("admin"))
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut(); 
            Response.Redirect("~/Login.aspx"); 

        }
    }
}