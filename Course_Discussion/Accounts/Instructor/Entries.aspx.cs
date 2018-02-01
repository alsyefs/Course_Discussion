using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Discussion.Accounts.Instructor
{
    public partial class Entries : System.Web.UI.Page
    {
        string username = "", discussionId = "";
        int roleId = 0;
        SqlConnection connect = new SqlConnection("Data Source = R14\\SALEH;Initial Catalog = Course_Discussion; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckInstructor checkInstructor = new CheckInstructor();
            username = (string)(Session["username"]);
            roleId = (int)(Session["roleId"]);
            discussionId = Request.QueryString["id"]; //To be used in Entities.aspx to get the query string.            
            Boolean correct = checkInstructor.sessionIsCorrect(username, roleId);
            if (correct)
            {
                welcome();
            }
            else { Response.Redirect("~/default.aspx"); }
        }
        protected void welcome()
        {
            showHeader();
            int count = countEntries();
            if (count > 0)  
                showEntries(count);
            checkIfTerminated();            
        }
        protected void checkIfTerminated()
        {
            // hide 3 things if terminated.
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select discussion_terminated from discussions where discussionId = '"+discussionId+"' ";
            int terminated = Convert.ToInt32(cmd.ExecuteScalar());
            if(terminated == 1)
            {
                txtAddEntity.Visible = false;
                btnAddEntry.Visible = false;
                FileUpload1.Visible = false;
                lblError.Visible = true;
                lblError.Text = "This discussion has been terminated and no more entries can be added.";
            }
            connect.Close();
        }
        protected int countEntries()
        {
            connect.Open();
            int count = 0;
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from entries where discussionId = '" + discussionId + "' ";
            count = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            return count;
        }
        protected void showEntries(int count)
        {                        
            string entryId = "", entryUsername = "", entryTime = "", entryText = "", result = "";
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;            
            cmd.CommandText = "select MAX(entryId) from entries";
            int totalEntries = Convert.ToInt32(cmd.ExecuteScalar());
            int i = 1, entriesFound = 0;
            while (i <= totalEntries)
            {                                
                cmd.CommandText = "select count(*) from entries where entryId = '" + i + "' and discussionId = '" + discussionId + "' ";
                int countEntry = Convert.ToInt32(cmd.ExecuteScalar());
                if (countEntry > 0)
                {
                    //HyperLink deleteLink = new HyperLink();
                    //deleteLink.Text = "Remove entry " + i;
                    //deleteLink.NavigateUrl = "~/Accounts/Instructor/DeleteEntry.aspx?entryId="+i+"&id="+discussionId;
                    entriesFound++;
                    entryId = i.ToString();
                    cmd.CommandText = "select userId from entries where entryId = '" + entryId + "' ";
                    string userId = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "select loginId from users where userId = '" + userId + "' ";
                    string loginId = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "select username from logins where loginId = '" + loginId + "' ";
                    entryUsername = cmd.ExecuteScalar().ToString();
                    entryTime = getEntryTime(entryId);
                    cmd.CommandText = "select entry_text from entries where entryId = '" + entryId + "' ";
                    entryText = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "select isImage from entries where entryId = '" + entryId + "' ";
                    int isImage = Convert.ToInt32(cmd.ExecuteScalar());
                    if (isImage == 1)
                    {
                        
                        result = result + "Entry " + entriesFound + " - added by " + entryUsername + " on " + entryTime + "<br />" +
                        "<img src='../../images/"+entryText+"'></img>" +
                        "<br /> " +
                    "<a href=\"DeleteEntry.aspx?entryId=" + entryId + "&id=" + discussionId + "\"" + "> Remove Entry " + entriesFound + "</a> <br />" +
                    "--------------------------------------------------------------------------------------------" +
                        "<br />";
                        lblEntry.Visible = true;
                        lblEntry.Text = result;
                    }
                    else
                    {
                        result = result + "Entry " + entriesFound + " - added by " + entryUsername + " on " + entryTime + "<br />" +
                            entryText + "<br /> " +
                        "<a href=\"DeleteEntry.aspx?entryId=" + entryId + "&id=" + discussionId + "\"" + "> Remove Entry " + entriesFound + "</a> <br />" +
                        "--------------------------------------------------------------------------------------------" +
                            "<br />";
                        lblEntry.Visible = true;
                        lblEntry.Text = result;
                    }                    
                                       
                }
                if (entriesFound == count)
                    break;
                i++;
            }

            connect.Close();
        }        
        protected void showHeader()
        {
            string result = "", name = "", course = "", topic = "", time = "";
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select userId from Discussions where discussionId = '" + discussionId + "' ";
            string userId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select firstname from users where userId = '" + userId + "' ";
            name = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select lastname from users where userId = '" + userId + "' ";
            name = name + " " + cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select courseId from Discussions where discussionId = '" + discussionId + "' ";
            string courseId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_code from Courses where courseId = '" + courseId + "' ";
            course = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_number from Courses where courseId = '" + courseId + "' ";
            course = course + " " + cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select course_name from Courses where courseId = '" + courseId + "' ";
            course = course + " - " + cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select discussion_topic from discussions where discussionId = '" + discussionId + "' ";
            topic = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select roleId from users where userId = '" + userId + "' ";
            string roleId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select role_name from roles where roleId = '" + roleId + "' ";
            string role_name = cmd.ExecuteScalar().ToString();
            time = getTimeFormat();
            connect.Close();
            result = "_______________________________________________________________________________________<br />" +
                "Creator: " + name + " (" + role_name + ")" + "<br />" +
                "Course name: " + course + "<br />" +
                "Topic: " + topic + "<br />" +
                "Created on: " + time + "<br />" +
                "_______________________________________________________________________________________";
            lblHeader.Visible = true;
            lblHeader.Text = result;
            //lblHeader.BackColor = System.Drawing.Color.DarkGreen;
            //lblHeader.ForeColor = System.Drawing.Color.LightBlue;
        }
        protected string getEntryTime(string entryId)
        {
            string result = "";
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select entry_time from entries where entryId = '" + entryId + "' ";
            result = cmd.ExecuteScalar().ToString();
            DateTime dateTime = Convert.ToDateTime(result);
            int month = dateTime.Month;
            int year = dateTime.Year;
            int day = dateTime.Day;
            string monthStr = getMonth(month);
            string time = dateTime.ToLongTimeString();
            result = monthStr + " " + day + ", " + year + " at " + time;
            return result;
        }
        protected string getTimeFormat()
        {
            string result = "";
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select discussion_time from Discussions where discussionId = '" + discussionId + "' ";
            result = cmd.ExecuteScalar().ToString();
            DateTime dateTime = Convert.ToDateTime(result);
            int month = dateTime.Month;
            int year = dateTime.Year;
            int day = dateTime.Day;
            string monthStr = getMonth(month);
            string time = dateTime.ToLongTimeString();
            result = monthStr + " " + day + ", " + year + " at " + time;
            return result;
        }
        protected void btnAddEntry_Click(object sender, EventArgs e)
        {
            Boolean correct = checkInput();
            if (correct)
            {
                addNewEntry();
                refreshPage();
            }
        }
        protected void refreshPage()
        {
            Response.Redirect("~/Accounts/Instructor/Entries.aspx?id="+discussionId);
        }
        protected DateTime getCurrentTime()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime;
        }
        protected string getImageName()
        {
            string name = "";
            string path = Server.MapPath("~/images/" + FileUpload1.FileName);
            //Bitmap image = (Bitmap)Image.FromFile(FileUpload1.PostedFile.InputStream);
            //Bitmap newBitmap = new Bitmap(image);
            //image_copy.SetResolution(200, 200);
            //image_copy.Save(Server.MapPath("~/images/" + image, ImageFormat.Jpeg);

            //--------THE BELOW WORKS:
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);
            System.Drawing.Bitmap image_copy = new System.Drawing.Bitmap(image);

            System.Drawing.Image img = RezizeImage(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream), 500, 500);
            img.Save(path, ImageFormat.Jpeg);            
            //image_copy.SetResolution(5, 5);   // This does nothing so far.
            //image_copy.Save(path, ImageFormat.Jpeg);

            //--------THE BELOW WORKS:
            //FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));

            name = FileUpload1.FileName;            
            return name;
        }
        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }
        private System.Drawing.Image RezizeImage(System.Drawing.Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }

        }
        protected void addNewEntry()
        {
            string entry_text = ""; int isImage = 0;
            if (FileUpload1.HasFile)
            {
               entry_text = getImageName();
                isImage = 1;
            }
            else
                entry_text = txtAddEntity.Text;
            DateTime entry_time = getCurrentTime();
            connect.Open();            
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select loginId from logins where username = '" + username + "' ";
            string loginId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "select userId from users where loginId = '" + loginId + "' ";
            string userId = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "insert into entries(discussionId, userId, entry_time, entry_text, isImage) values"+
                "('"+discussionId+"', '"+userId+"', '"+entry_time+"', '"+entry_text+"', '"+ isImage + "')";
            cmd.ExecuteScalar();
            connect.Close();
        }
        protected Boolean checkInput()
        {
            Boolean correct = true;
            
            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                int filesize = FileUpload1.PostedFile.ContentLength;
                string filename = FileUpload1.FileName;
                if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".tiff" && fileExtension.ToLower() != ".jpeg" &&
                    fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".gif" && fileExtension.ToLower() != ".bmp" &&
                    fileExtension.ToLower() != ".tif")
                {
                    correct = false;
                    lblError.Visible = true;
                    lblError.Text = "File Error: The supported formats for files are: jpg, jpeg, tif, tiff, png, gif, and bmp.";                    
                }                
                
                if (filesize > 5242880)
                {
                    correct = false;
                    lblError.Visible = true;
                    lblError.Text = "File Error: The size of any uploaded file needs to be less than 5MB.";
                }
                if (string.IsNullOrWhiteSpace(filename))
                {
                    correct = false;
                    lblError.Visible = true;
                    lblError.Text = "File Error: The file you are trying to upload must have a name.";
                }                                
            }
            else if (string.IsNullOrWhiteSpace(txtAddEntity.Text) && FileUpload1.HasFile == false)
            {
                correct = false;
                lblError.Visible = true;
                lblError.Text = "Input Error: Please type something for the entry or upload an image.";
            }
            if (correct)
                lblError.Visible = false;
            return correct;
        }        
        protected string getMonth(int month)
        {
            string result = "";
            if (month == 1)
                result = "Jan";
            else if (month == 2)
                result = "Feb";
            else if (month == 3)
                result = "Mar";
            else if (month == 4)
                result = "Apr";
            else if (month == 5)
                result = "May";
            else if (month == 6)
                result = "Jun";
            else if (month == 7)
                result = "Jul";
            else if (month == 8)
                result = "Aug";
            else if (month == 9)
                result = "Sep";
            else if (month == 10)
                result = "Oct";
            else if (month == 11)
                result = "Nov";
            else if (month == 12)
                result = "Dec";
            return result;
        }
    }
}