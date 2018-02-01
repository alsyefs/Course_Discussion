using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_Discussion
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection("Data Source = R14\\SALEH;Initial Catalog = Course_Discussion; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                fillDropRole();
        }
        protected void fillDropRole()
        {            
            drpRole.Items.Add("Choose user type");
            drpRole.Items.Add("Instructor");
            drpRole.Items.Add("Expert");
            drpRole.Items.Add("Intermediate");
            drpRole.Items.Add("Beginner");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int roleId = check(username, password);
            if (roleId != 0)
            {
                Boolean correctRoleSelected = roleIdMatchedSelectedRole(roleId);
                if (correctRoleSelected)
                    success(username, roleId);
            }
        }
        protected Boolean roleIdMatchedSelectedRole(int roleId)
        {
            Boolean correct = true;
            int selectedRole = drpRole.SelectedIndex;
            if (selectedRole != roleId)
            {
                correct = false;
                lblRoleError.Visible = true;
                lblRoleError.Text = "Input Error: Please select the correct role.";
            }            
            else
                lblRoleError.Visible = false;
            return correct;
        }
        protected int check(string username, string password)
        {
            int actualRoleId = 0;
            string errorMessage = "Value Error: Make sure you have entered the correct username and password.";
            int flag = 1;// flag 1 means everything is good.
            flag = checkIfEmpty();
            if (flag == 1)//if input is correct.
            {
                Boolean exists = checkIfExists(username); //check if username in DB.
                if (exists)//if user exists in the DB.
                {
                    Boolean correctPassword = checkPassword(username, password); //check if password is correct.
                    if (correctPassword)
                    {
                        int roleId = findRole(username); //find the roleId.                        
                        //success(username, roleId); //instead, return the found role ID.
                        actualRoleId = roleId;
                    }
                    else //if password incorrect, display the same message for security reasons.
                    {
                        lblError.Visible = true;
                        lblError.Text = errorMessage;
                    }
                }
                else // if user does not exist in DB.
                {
                    lblError.Visible = true;
                    lblError.Text = errorMessage;
                }

            }
            return actualRoleId;
        }
        protected int checkIfEmpty()
        {
            int flag = 1;
            if (string.IsNullOrWhiteSpace(txtUsername.Text))//if user leaves blank.
            {
                flag = 0;
                lblUsernameError.Visible = true;
                lblUsernameError.Text = "Input Error: Type a username.";
            }
            else if (txtUsername.Text.Length < 6)
            {
                flag = 0;
                lblUsernameError.Visible = true;
                lblUsernameError.Text = "Input Error: Username must be more than six characters.";
            }
            else
            {
                lblUsernameError.Visible = false;
                lblUsernameError.Text = "";//clear text in case for another try username is filled but password not filled.
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                flag = 0;
                lblPasswordError.Visible = true;
                lblPasswordError.Text = "Input Error: Type a password.";
            }
            else if (txtPassword.Text.Length < 6)
            {
                flag = 0;
                lblPasswordError.Visible = true;
                lblPasswordError.Text = "Input Error: Password must be more than six characters.";
            }
            else
            {
                lblPasswordError.Visible = false;
                lblPasswordError.Text = "";
            }
            if(drpRole.SelectedIndex == 0)
            {
                flag = 0;
                lblRoleError.Visible = true;
                lblRoleError.Text = "Input Error: Choose a user type.";
            }
            else
            {
                lblRoleError.Visible = false;
                lblRoleError.Text = "";                
            }
            
            return flag;
        }
        protected Boolean checkIfExists(string username)
        {
            Boolean exists = true;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from logins where username like '" + username + "' ";
            int countUser = Convert.ToInt32(cmd.ExecuteScalar());
            if (countUser < 1) //user does not exist.
            {
                exists = false;
                //lblError.Visible = true;
                //lblError.Text = username+" does not exist";
            }

            connect.Close();
            return exists;
        }
        protected Boolean checkPassword(string username, string password)
        {
            Boolean correct = true;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count (*) from logins where username like '" + username + "' and password like '" + password + "' ";
            int correctCombination = Convert.ToInt32(cmd.ExecuteScalar()); //count matching. result either 0 or 1.
            if (correctCombination == 0)
            {
                correct = false;
            }
            connect.Close();
            return correct;
        }

        protected int findRole(string username)
        {
            int roleId = 0;
            connect.Open();
            SqlCommand cmd = connect.CreateCommand();
            cmd.CommandText = "select count(roleId) from logins where username like '" + username + "'";
            int isThereRoleInDB = Convert.ToInt32(cmd.ExecuteScalar());
            if (isThereRoleInDB > 0) //means the user has a stored roleId in DB. This is to prevent DB error.
            {
                cmd.CommandText = "select roleId from logins where username like '" + username + "'";
                roleId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else //DB error: roleId was not stored for user. It is an extreme case, but it can happen somehow.
            {
                lblError.Visible = true;
                lblError.Text = "Database Error: Username has no role. Please contact the support.";
            }
            connect.Close();
            return roleId;
        }
        protected void success(string username, int roleId)
        {
            Session.Add("username", username);
            Session.Add("roleId", roleId);
            if (roleId == 1)
            {
                //Instructor.
                Response.Redirect("~/Accounts/Instructor/Home.aspx");
            }
            else if (roleId == 2)
            {
                //Expert.
                Response.Redirect("~/Accounts/Expert/Home.aspx");
            }
            else if (roleId == 3)
            {
                //Intermediate.
                Response.Redirect("~/Accounts/Intermediate/Home.aspx");
            }
            else if (roleId == 4)
            {
                //Beginner.
                Response.Redirect("~/Accounts/Beginner/Home.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}