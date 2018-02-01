using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Discussion.Accounts.Beginner
{
    public partial class Help : System.Web.UI.Page
    {
        string username = "";
        int roleId = 0;
        SqlConnection connect = new SqlConnection("Data Source = R14\\SALEH;Initial Catalog = Course_Discussion; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBeginner checkBeginner = new CheckBeginner();
            username = (string)(Session["username"]);
            roleId = (int)(Session["roleId"]);
            Boolean correct = checkBeginner.sessionIsCorrect(username, roleId);
            if (correct)
            {
                welcome();
            }
            else { Response.Redirect("~/default.aspx"); }
        }
        protected void welcome()
        {
            //int count = getNumberOfDiscussions();
            //if (count > 0)
            //{
            //    createTable(count);
            //}
        }
    }
}