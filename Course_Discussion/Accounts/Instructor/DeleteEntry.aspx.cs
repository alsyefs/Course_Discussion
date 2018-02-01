using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Discussion.Accounts.Instructor
{
    public partial class DeleteEntry : System.Web.UI.Page
    {
        string username = "", discussionId = "", entryId = "";
        int roleId = 0;
        SqlConnection connect = new SqlConnection("Data Source = R14\\SALEH;Initial Catalog = Course_Discussion; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckInstructor checkInstructor = new CheckInstructor();
            username = (string)(Session["username"]);
            roleId = (int)(Session["roleId"]);
            discussionId = Request.QueryString["id"];
            entryId = Request.QueryString["entryId"];
            Boolean correct = checkInstructor.sessionIsCorrect(username, roleId);
            if (correct)
            {
                welcome();
            }
            else { Response.Redirect("~/default.aspx"); }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;            
            cmd.CommandText = "delete from entries where entryId = '"+entryId+"' ";
            cmd.ExecuteScalar();
            lblMessage.Visible = true;
            lblMessage.Text = "The entry ("+entryId+") has been successfully deleted!";
            btnYes.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accounts/Instructor/Entries.aspx?id="+discussionId);
        }

        protected void welcome()
        {
            showEntryInformation();
        }
        protected void showEntryInformation()
        {
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;            
            cmd.CommandText = "select count(*) from entries where entryId = '"+entryId+"' ";
            int countEntries = Convert.ToInt32(cmd.ExecuteScalar());
            if(countEntries > 0)
            {
                cmd.CommandText = "select entry_text from entries where entryId = '" + entryId + "' ";
                string entry_text = cmd.ExecuteScalar().ToString();
                lblInformation.Text = "Are you sure you want to delete this entry? <br /> <br />";
                    

                //lblInformation.Text = "Are you sure you want to delete the entry ("+entryId + ") which has the following text: <br />"+
                //    entry_text + "<br />";

            }

            connect.Close();
        }
    }
}