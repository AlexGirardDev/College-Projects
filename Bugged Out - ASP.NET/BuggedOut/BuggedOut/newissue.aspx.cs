using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;

namespace BuggedOut
{
    public partial class newissue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Check to make sure data is valid if not Display what needs to be changes
        private bool dataGood()
        {
            Boolean isOk = true;

            if (drpLstProjName.SelectedItem.Text.Equals(""))
            {
                lblProjNameError.Text = "Please make a Selection!";
                isOk = false;
            }
            if (drpLstCategory.SelectedItem.Text.Equals(""))
            {
                lblCategoryError.Text = "Please make a Selection!";
                isOk = false;
            }
            if (drpLstStatus.SelectedItem.Text.Equals(""))
            {
                lblStatusError.Text = "Please make a Selection!";
                isOk = false;
            }     
            if (drpLstPriority.SelectedItem.Text.Equals(""))
            {
                lblPriorityError.Text = "Please make a Selection!";
                isOk = false;
            }   
            if (txtDescBox.Text.Length > 255)
            {
                lblDescError.Text = "Description text is to long. Shorten it to under 255 characters.";
                isOk = false;
            }

            return isOk;
        }
        //Submits the issue to the database
        protected void submitIssue_Click(object sender, EventArgs e)
        {
            lblProjNameError.Text = "";
            lblCategoryError.Text = "";
            lblPriorityError.Text = "";
            lblStatusError.Text = "";
            lblDescError.Text = "";

         //Checks if dataGood is good before submitting to database
            if (dataGood() == true)
            {
                string connStr = ConfigurationManager.ConnectionStrings["connStr_BuggedOutDB"].ConnectionString;
                SqlConnection conn = null;
                 try
                 {
                     conn = new SqlConnection(connStr);
                     conn.Open();
                     SqlCommand cmd = new SqlCommand();
                     cmd.Connection = conn;
                     string sql = "INSERT INTO [tIssues] ([projectName],[createdBy],[assignedTo],[category],[priority],[status], [dateCreate],[lastUpdate],[issueTitle],[issueDescription]) VALUES ('" + drpLstProjName.SelectedItem.Text + "','" + txtCreatedBy.Text + "','" + txtAssignedTo.Text + "','" + drpLstCategory.SelectedItem.Text + "','" + drpLstPriority.SelectedItem.Text + "','" + drpLstStatus.SelectedItem.Text + "',GETDATE(),GETDATE(),'" + txtTitle.Text + "','" + txtDescBox.Text + "')";
                     Response.Write(sql);
                     cmd.CommandText = sql;
                     cmd.ExecuteNonQuery();

                     cmd.CommandText = "SELECT [issueId] FROM [tIssues] ORDER BY [issueId] DESC";
                     SqlDataReader dr = cmd.ExecuteReader();

                     int issueId = -1;
                     if (dr.HasRows)
                     {
                         dr.Read();
                         issueId = Convert.ToInt32(dr["issueId"]);
                     }

                     dr.Close();
                     
                     cmd.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueId + ", GETDATE(), ' ', 'Issue Created')";
                     cmd.ExecuteNonQuery();

                     conn.Close();

                     List<int> myIssues = (List<int>)Session["issuesMade"];

                     if (myIssues == null)
                     {
                         myIssues = new List<int>();
                     }

                     if (issueId != -1)
                     {
                         myIssues.Add(issueId);
                         Session["issuesMade"] = myIssues;

                         Response.Redirect("issueinfo.aspx?issueID=" + issueId);
                     }
                     else
                     {
                         Response.Redirect("home.aspx");
                     }
                 }
                 catch (SqlException ex)
                 {
                     if (conn != null)
                     {
                         conn.Close();
                     }
                     Response.Write(ex.Message);
                 }
            }
        }
    }
}