using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Discussion.Accounts.Instructor
{
    public partial class CreateDiscussion : System.Web.UI.Page
    {
        string username = "";
        int roleId = 0;
        SqlConnection connect = new SqlConnection("Data Source = R14\\SALEH;Initial Catalog = Course_Discussion; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckInstructor checkInstructor = new CheckInstructor();
            username = (string)(Session["username"]);
            roleId = (int)(Session["roleId"]);
            Boolean correct = checkInstructor.sessionIsCorrect(username, roleId);
            if (correct)
            {
                welcome();
            }
            else { Response.Redirect("~/default.aspx"); }
        }

        protected void welcome()
        {
            string topic = txtTopic.Text;
            if (!IsPostBack)
                fillDrpCourse();
        }
        protected void fillDrpCourse()
        {
            ArrayList list = getList();
            drpCourse.Items.Add("Select from the this list");
            foreach (string item in list)
            {
                drpCourse.Items.Add(item);
            }                   
        }
        protected ArrayList getList()
        {
            ArrayList list = new ArrayList();
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(courseId) from courses";
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            string item = "";
            for (int i = 1; i <= count; i++)
            {
                cmd.CommandText = "select course_code from courses where courseId = " + i;
                item = cmd.ExecuteScalar().ToString();
                cmd.CommandText = "select course_number from courses where courseId = " + i;
                item = item + cmd.ExecuteScalar().ToString() + " ";
                cmd.CommandText = "select course_name from courses where courseId = " + i;
                item = item + cmd.ExecuteScalar().ToString();
                list.Add(item);
            }
            connect.Close();
            return list;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Boolean correct = correctInput();
            if (correct)
            {
                createNewDiscussion();
                success();
            }
        }
        protected void success()
        {
            lblSuccess.Visible = true;
            lblSuccess.Text = "The discussion has been successfully created!";
        }
        protected int getUserId()
        {            
            int userId = 0;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select loginId from Logins where username like '"+username+"' ";
            int loginId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "select userId from Users where loginId = '" + loginId + "' ";
            userId = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            return userId;
        }
        protected int getCourseId()
        {            
            int courseId = drpCourse.SelectedIndex;            
            return courseId;
        }
        protected DateTime getDiscussionTime()
        {
            DateTime dateTime = DateTime.Now;            
            return dateTime;
        }
        protected void createNewDiscussion()
        {
            int userId = getUserId();
            int courseId = getCourseId();
            DateTime discussion_time = getDiscussionTime();
            string discussion_topic = txtTopic.Text;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into discussions(userId, courseId, discussion_time, discussion_topic, discussion_terminated) values"+
                "('"+ userId + "', '"+ courseId + "', '"+ discussion_time + "', '"+ discussion_topic + "', '0')";
            cmd.ExecuteScalar();
            connect.Close();
        }
        protected Boolean correctInput()
        {
            Boolean correct = true;
            if (string.IsNullOrWhiteSpace(txtTopic.Text))
            {
                correct = false;
                lblTopicError.Visible = true;
                lblTopicError.Text = "Input Error: Please do not leave the topic field empty.";
            }
            else
                lblTopicError.Visible = false;
            if (drpCourse.SelectedIndex == 0)
            {
                correct = false;
                lblCourseError.Visible = true;
                lblCourseError.Text = "Input Error: Please select a course from the list.";
            }
            else
                lblCourseError.Visible = false;
            return correct;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accounts/Instructor/Home.aspx");
        }
    }
}