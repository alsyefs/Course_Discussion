using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Discussion.Accounts.Intermediate
{
    public partial class Help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "";
            int roleId = 0;
            SqlConnection connect = new SqlConnection("Data Source = R14\\SALEH;Initial Catalog = Course_Discussion; Integrated Security = True");
            CheckIntermediate checkIntermediate = new CheckIntermediate();
            username = (string)(Session["username"]);
            roleId = (int)(Session["roleId"]);
            Boolean correct = checkIntermediate.sessionIsCorrect(username, roleId);
            if (correct)
            {
                //welcome();
            }
            else { Response.Redirect("~/default.aspx"); }
        }
    }
}