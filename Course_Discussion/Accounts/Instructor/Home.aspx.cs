using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Course_Discussion.Accounts.Instructor
{
    public partial class Home : System.Web.UI.Page
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
            if (correct) {
                welcome();
            }
            else { Response.Redirect("~/default.aspx"); }
        }
        protected void welcome()
        {
            int count = getNumberOfDiscussions();
            if (count > 0)
            {
                createTable(count);                 
            }
        }
        
        protected void createTable(int count)
        {                       
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Topic", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Course", typeof(string));
            dt.Columns.Add("Course Name", typeof(string));
            dt.Columns.Add("Created By:", typeof(string));
            dt.Columns.Add("Terminated?", typeof(string));
            string id = "", topic = "", time = "", course = "", courseName = "", createdBy = "", terminated = "Still Active";
            int isTerminated = 0;
            int counter = 1;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            for (int i = 1; i <= count; i++)
            {
                cmd.CommandText = "select discussionId from Discussions where discussionId = '" + i + "' ";
                id = cmd.ExecuteScalar().ToString();
                cmd.CommandText = "select discussion_topic from Discussions where discussionId = '" + i + "' ";
                topic = cmd.ExecuteScalar().ToString();
                cmd.CommandText = "select discussion_time from Discussions where discussionId = '" + i + "' ";
                time = cmd.ExecuteScalar().ToString();
                cmd.CommandText = "select discussion_terminated from Discussions where discussionId = '" + i + "' ";
                isTerminated = Convert.ToInt32(cmd.ExecuteScalar());
                if (isTerminated == 0)
                    terminated = "Still Active";
                else
                    terminated = "TERMINATED";
                course = getCourse(i);
                courseName = getCourseName(i);
                createdBy = getCreator(i);
                //id = counter.ToString();
                //counter++;
                dt.Rows.Add( id, topic, time, course, courseName, createdBy, terminated);                
            }
            connect.Close();
            grdDiscussions.DataSource = dt;
            grdDiscussions.DataBind();
        }       
        protected string getCreator(int i)
        {
            string createdBy = "";
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select userId from Discussions where discussionId = '" + i + "' ";
            string userId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select firstname from Users where userId = '" + userId + "' ";
            string firstname = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select lastname from Users where userId = '" + userId + "' ";
            string lastname = cmd.ExecuteScalar().ToString();
            createdBy = firstname + " " + lastname;
            return createdBy;
        }
        protected string getCourseName(int i)
        {
            string courseName = "";
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select courseId from Discussions where discussionId = '" + i + "' ";
            string courseId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_name from Courses where courseId = '" + courseId + "' ";
            courseName = cmd.ExecuteScalar().ToString();
            return courseName;
        }
        protected string getCourse(int i)
        {
            string course = "";
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select courseId from Discussions where discussionId = '" + i + "' ";
            string courseId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_code from Courses where courseId = '" + courseId + "' ";
            string course_code = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_number from Courses where courseId = '" + courseId + "' ";
            string course_number = cmd.ExecuteScalar().ToString();
            course = course_code + course_number;
            return course;
        }
       
        protected int getNumberOfDiscussions()
        {
            int count = 0;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from Discussions ";
            count = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            return count;
        }

        protected int getNumberOfDiscussionsForSearch(string searchTerm)
        {
            int count = 0;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from Discussions where discussion_topic like '%"+searchTerm+"%' ";
            count = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            return count;
        }
        protected void grdDiscussions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grdDiscussions.SelectedRow.ToString();
            //grdDiscussions.PageIndex = e.NewPageIndex;
            //grdDiscussions.DataBind();
        }
        protected void grdDiscussions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //FillGrid();
            //int count = getNumberOfDiscussions();
            //if (count > 0)
            //{
            //    createTable(count);
            //}
            grdDiscussions.PageIndex = e.NewPageIndex;
            grdDiscussions.DataBind();
        }
        protected Boolean hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
                if (input.Equals("'")) return true;
                if (input.Equals("\"")) return true;
            }

            return false;
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            Boolean hasSpecialCharacter = hasSpecialChar(searchTerm);
            int count = getNumberOfDiscussions();
            int foundTopics = 0;
            if(hasSpecialCharacter == false)
                foundTopics = getNumberOfDiscussionsForSearch(searchTerm);
            //check if the search input is at least 3 chars
            if (searchTerm.Length > 0 && foundTopics > 0 && hasSpecialCharacter == false)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Topic", typeof(string));
                dt.Columns.Add("Time", typeof(string));
                dt.Columns.Add("Course", typeof(string));
                dt.Columns.Add("Course Name", typeof(string));
                dt.Columns.Add("Created By:", typeof(string));
                dt.Columns.Add("Terminated?", typeof(string));
                string id = "", topic = "", time = "", course = "", courseName = "", createdBy = "", terminated = "Still Active";
                int isTerminated = 0;
                connect.Open();
                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //for (int i = 1; i <= count; i++)
                int i = 1;
                int counter = 1;
                while (count > 0)
                {
                    cmd.CommandText = "select count(discussionId) from Discussions where discussion_topic like '%" + searchTerm + "%' and discussionId = '"+i+"' ";
                    int discussionCounter = Convert.ToInt32(cmd.ExecuteScalar());
                    if (discussionCounter > 0)
                    {                        
                        id = i.ToString();
                        cmd.CommandText = "select discussion_topic from Discussions where discussionId = '"+id+"' ";
                        topic = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "select discussion_time from Discussions where discussionId = '" + id + "' ";
                        time = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "select discussion_terminated from Discussions where discussionId = '" + id + "' ";
                        isTerminated = Convert.ToInt32(cmd.ExecuteScalar());
                        if (isTerminated == 0)
                            terminated = "Still Active";
                        else
                            terminated = "TERMINATED";
                        course = getCourse(i);
                        courseName = getCourseName(i);
                        createdBy = getCreator(i);
                        //id = counter.ToString();
                        //counter++;
                        dt.Rows.Add(id, topic, time, course, courseName, createdBy, terminated);
                    }
                    i++;
                    count--;
                }
                connect.Close();
                grdDiscussions.DataSource = dt;
                grdDiscussions.DataBind();

                lblSearchError.Visible = false;
            }
            else if (hasSpecialCharacter)
            {
                lblSearchError.Visible = true;
                lblSearchError.Text = "Input Error: Special charatcers like ( " + searchTerm + " ) are not allowed in the search field.";
            }
            else if(foundTopics == 0)
            {
                lblSearchError.Visible = true;
                lblSearchError.Text = "The search returned no results for '"+searchTerm+"' ";
            }
            else
            {
                lblSearchError.Visible = true;
                lblSearchError.Text = "Input Error: The search field cannot be empty.";
            }
        }
    }
}