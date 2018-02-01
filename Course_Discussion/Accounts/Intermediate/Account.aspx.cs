using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Discussion.Accounts.Intermediate
{
    public partial class Account : System.Web.UI.Page
    {

        string username = "";
        int roleId = 0;
        SqlConnection connect = new SqlConnection("Data Source = R14\\SALEH;Initial Catalog = Course_Discussion; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckIntermediate checkBeginner = new CheckIntermediate();
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
            lblUsernameOutput.Text = username;
            string userId = getUserId();
            createTable();
            //lblCoursesOutput.Text = getRegisteredCourses(userId);
        }

        protected void createTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Course", typeof(string));
            dt.Columns.Add("Course Name", typeof(string));
            dt.Columns.Add("Credits", typeof(string));
            string id = "", courseId = "", course = "", courseName = "", credits = "";
            int isTerminated = 0;
            string userId = getUserId();
            //ArrayList userCourse = getCourseId(userId);
            //int totalDiscussions = discussionsForUser(userCourse);
            //int tempTotal = totalDiscussions;
            //int maxId = maxDiscussionsForUser(userCourse);
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from registrations where userId = '" + userId + "' ";
            int totalCoursesRegisred = Convert.ToInt32(cmd.ExecuteScalar());
            if (totalCoursesRegisred == 0)
            {
                lblCoursesOutput.Visible = true;
                grdCourses.Visible = false;
                lblCoursesOutput.Text = "You are not registered for any course.";
            }
            else
            {
                lblCoursesOutput.Visible = false;
                grdCourses.Visible = true;
                cmd.CommandText = "select MAX(registerId) from registrations ";
                int totalRegistraions = Convert.ToInt32(cmd.ExecuteScalar());
                int counter = 1;
                for (int i = 1; i <= totalRegistraions; i++)
                {
                    cmd.CommandText = "select count(*) from registrations where  registerId = '" + i + "' and userId = '" + userId + "'  ";
                    int foundMatch = Convert.ToInt32(cmd.ExecuteScalar());
                    if (foundMatch > 0)
                    {
                        id = i.ToString();
                        cmd.CommandText = "select courseId from registrations where  registerId = '" + i + "' and userId = '" + userId + "'  ";
                        courseId = cmd.ExecuteScalar().ToString();

                        cmd.CommandText = "select course_code from courses where courseId = '" + courseId + "' ";
                        course = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "select course_number from courses where courseId = '" + courseId + "' ";
                        course = course + "" + cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "select course_name from courses where courseId = '" + courseId + "' ";
                        courseName = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "select course_credits from courses where courseId = '" + courseId + "' ";
                        credits = cmd.ExecuteScalar().ToString();
                        id = counter.ToString();
                        counter++;
                        dt.Rows.Add(id, course, courseName, credits);
                    }
                }
            }
            connect.Close();
            grdCourses.DataSource = dt;
            grdCourses.DataBind();
        }

        protected string getUserId()
        {
            string userId = "";
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select loginId from logins where username like '" + username + "' ";
            string loginId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select userId from users where loginId like '" + loginId + "' ";
            userId = cmd.ExecuteScalar().ToString();
            connect.Close();
            return userId;
        }
        protected string getCourseInformation(string courseId)
        {
            string courseInformation = "";
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select course_code from courses where courseId = '" + courseId + "' ";
            courseInformation = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_number from courses where courseId = '" + courseId + "' ";
            courseInformation = courseInformation + "" + cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_name from courses where courseId = '" + courseId + "' ";
            courseInformation = courseInformation + " " + cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_credits from courses where courseId = '" + courseId + "' ";
            courseInformation = courseInformation + " " + cmd.ExecuteScalar().ToString();
            return courseInformation;
        }

        protected void grdCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCourses.PageIndex = e.NewPageIndex;
            grdCourses.DataBind();
        }
        //protected string getRegisteredCourses(string userId)
        //{
        //    //course_code="", course_number="", course_name = "", course_credits = ""
        //    string result = "", courseId="", courseInformation = "" ;
        //    connect.Open();
        //    SqlCommand cmd = connect.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    //cmd.CommandText = "select count(*) from registrations where userId = '"+userId+"' ";
        //    //int totalCoursesRegisred = Convert.ToInt32(cmd.ExecuteScalar());
        //    //if (totalCoursesRegisred == 0)
        //    //    result = "You are not registered for any course.";
        //    else
        //    {                
        //        cmd.CommandText = "select MAX(registerId) from registrations ";
        //        int totalRegistraions = Convert.ToInt32(cmd.ExecuteScalar());
        //        for(int i = 1; i <= totalRegistraions; i++)
        //        {
        //            cmd.CommandText = "select count(*) from registrations where  registerId = '"+i+"' and userId = '"+userId+"'  ";
        //            int foundMatch = Convert.ToInt32(cmd.ExecuteScalar());
        //            if(foundMatch > 0)
        //            {
        //                cmd.CommandText = "select courseId from registrations where  registerId = '" + i + "' and userId = '" + userId + "'  ";
        //                courseId = cmd.ExecuteScalar().ToString();
        //                courseInformation = getCourseInformation(courseId);
        //                result = courseInformation + " <br />";
        //            }
        //        }
        //    }
        //    connect.Close();
        //    return result;
        //}


    }
}