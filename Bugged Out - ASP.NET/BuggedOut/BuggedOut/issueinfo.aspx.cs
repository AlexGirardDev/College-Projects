using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Configuration;

namespace BuggedOut
{
    public partial class viewissue : System.Web.UI.Page
    {
        SqlConnection connection = null;
        int issueID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection qsValues = Request.QueryString;
            string str_issueID = qsValues.Get("issueID");
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr_BuggedOutDB"].ConnectionString);

            if (str_issueID == null)
            {
                Response.Redirect("home.aspx");
            }

            issueID = Convert.ToInt32(str_issueID);

            if (!IsPostBack) // If not a postback
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM [tIssues] WHERE issueID = " + issueID;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read(); //Advance to first row (There can only be one, as it is using PK to filter)

                        //Set issue ID label
                        lblIssueID.Text = reader["issueID"].ToString();

                        //Set Project Selection and store original value
                        drpLstProjName.Items.FindByText(reader["projectName"].ToString()).Selected = true;
                        Session["origProj"] = drpLstProjName.SelectedItem.Text;

                        //Set created by label
                        lblCreatedBy.Text = reader["createdBy"].ToString();

                        //Set Assigned to label and store original value                       
                        txtAssignedTo.Text = reader["assignedTo"].ToString();
                        Session["origAssigned"] = txtAssignedTo.Text;

                        //Set selected category and store original value
                        drpLstCategory.Items.FindByText(reader["category"].ToString()).Selected = true;
                        Session["origCategory"] = drpLstCategory.SelectedItem.Text;

                        //Select correct index and store original
                        drpLstStatus.Items.FindByText(reader["status"].ToString()).Selected = true;
                        Session["origStatus"] = drpLstStatus.SelectedItem.Text;

                        //Select proper priority, and store that index
                        drpLstPriority.Items.FindByText(reader["priority"].ToString()).Selected = true; ;
                        Session["origPriority"] = drpLstPriority.SelectedItem.Text;

                        lblDateCreated.Text = reader["dateCreate"].ToString();
                        lblLastUpdate.Text = reader["lastUpdate"].ToString();

                        //Store and set summary and details
                        txtSummary.Text = reader["issueTitle"].ToString();
                        Session["origSummary"] = txtSummary.Text;
                        txtDetails.Text = reader["issueDescription"].ToString();
                        Session["origDesc"] = txtDetails.Text;

                        reader.Close();
                        connection.Close();

                        displayLog();
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();

                        Response.Redirect("noissuesfound.aspx?issueID=" + issueID);
                    }


                }
                catch (SqlException ex)
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                    Response.Write("SQL Error: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    command.CommandText = "SELECT [lastUpdate] FROM [tIssues] WHERE issueID = " + issueID;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read(); //Advance to first row (There can only be one, as it is using PK to filter)

                        lblLastUpdate.Text = reader["lastUpdate"].ToString(); //Set the last update time

                        reader.Close();
                        connection.Close();

                        displayLog();
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();

                        Response.Redirect("noissuesfound.aspx?issueID=" + issueID);
                    }

                }
                catch (SqlException ex)
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                    Response.Write("SQL Error: " + ex.Message);
                }
            }
        }

        private void displayLog()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT [updateDate], [updatedField], [updateDescription] FROM [tIssueLog] WHERE issueID = " + issueID;
                SqlDataReader dr = cmd.ExecuteReader();

                updateGridView.DataSource = dr;
                updateGridView.DataBind();

                dr.Close();
                connection.Close();
            }
            catch (SqlException ex)
            {
                if (connection != null)
                {
                    connection.Close();
                }

                Response.Write("SQL Error: " + ex.Message);
            }
        }

        private bool descLengthGood()
        {
            lblLengthError.Text = "";

            if (txtDetails.Text.Length > 255)
            {
                lblLengthError.Text = "Too many characters in details.\nPlease limit field to 255 characters.";
                return false;
            }

            return true;
        }

        protected void cmdEditIssue_Click(object sender, EventArgs e)
        {
            if (descLengthGood())
            {
                localhost.StringTrimWebService stringTrim = new localhost.StringTrimWebService();

                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    command.CommandText = "UPDATE [tIssues] SET [projectName] = '" + drpLstProjName.SelectedItem.Text + "', [assignedTo] = '" + txtAssignedTo.Text + "', [category] = '" + drpLstCategory.SelectedItem.Text + "', [status] = '" + drpLstStatus.SelectedItem.Text + "', [priority] = '" + drpLstPriority.SelectedItem.Text + "', [issueTitle] = '" + txtSummary.Text + "', [issueDescription] = '" + txtDetails.Text + "', [lastUpdate] = GETDATE() WHERE issueID = " + issueID;

                    command.ExecuteNonQuery();

                    /***********ADD LOG ENTRIES************/

                    //Add a log entry if the project name has changed
                    if (!drpLstProjName.SelectedItem.Text.Equals(Session["origProj"].ToString()))
                    {
                        command.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueID + ", GETDATE(), 'Project Name', '" + Session["origProj"].ToString() + " ==> " + drpLstProjName.SelectedItem.Text + "')";
                        command.ExecuteNonQuery();
                        Session["origProj"] = drpLstProjName.SelectedItem.Text;
                    }

                    //Add a log entry if the assigned person has changed
                    if (!txtAssignedTo.Text.ToUpper().Equals(Session["origAssigned"].ToString().ToUpper()))
                    {
                        command.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueID + ", GETDATE(), 'Assigned To', '" + Session["origAssigned"].ToString() + " ==> " + txtAssignedTo.Text + "')";
                        command.ExecuteNonQuery();
                        Session["origAssigned"] = txtAssignedTo.Text;
                    }

                    //Add a log entry if th category has changed
                    if (!drpLstCategory.SelectedItem.Text.Equals(Session["origCategory"].ToString()))
                    {
                        command.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueID + ", GETDATE(), 'Category', '" + Session["origCategory"].ToString() + " ==> " + drpLstCategory.SelectedItem.Text + "')";
                        command.ExecuteNonQuery();
                        Session["origCategory"] = drpLstCategory.SelectedItem.Text;
                    }

                    //Add a log entry if the status has changed
                    if (!drpLstStatus.SelectedItem.Text.Equals(Session["origStatus"].ToString()))
                    {
                        command.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueID + ", GETDATE(), 'Status', '" + Session["origStatus"].ToString() + " ==> " + drpLstStatus.SelectedItem.Text + "')";
                        command.ExecuteNonQuery();
                        Session["origStatus"] = drpLstStatus.SelectedItem.Text;
                    }

                    //Add a log entry if the priority has changed
                    if (!drpLstPriority.SelectedItem.Text.Equals(Session["origPriority"].ToString()))
                    {
                        command.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueID + ", GETDATE(), 'Priority', '" + Session["origPriority"].ToString() + " ==> " + drpLstPriority.SelectedItem.Text + "')";
                        command.ExecuteNonQuery();
                        Session["origPriority"] = drpLstPriority.SelectedItem.Text;
                    }

                    //Add a log entry if the summary has changed
                    if (!Session["origSummary"].ToString().ToUpper().Equals(txtSummary.Text.ToUpper()))
                    {
                        command.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueID + ", GETDATE(), 'Summary', '" + stringTrim.TrimString(Session["origSummary"].ToString(), 15) + " ==> " + stringTrim.TrimString(txtSummary.Text, 15) + "')";
                        command.ExecuteNonQuery();
                        Session["origSummary"] = txtSummary.Text;
                    }

                    //Add a log entry if the details have changed
                    if (!Session["origDesc"].ToString().ToUpper().Equals(txtDetails.Text.ToUpper()))
                    {
                        command.CommandText = "INSERT INTO [tIssueLog]([issueID], [updateDate], [updatedField], [updateDescription]) VALUES (" + issueID + ", GETDATE(), 'Details', '" + stringTrim.TrimString(Session["origDesc"].ToString(), 15) + " ==> " + stringTrim.TrimString(txtDetails.Text, 15) + "')";
                        command.ExecuteNonQuery();
                        Session["origDesc"] = txtDetails.Text;
                    }

                    connection.Close();

                    displayLog();
                }
                catch (SqlException ex)
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }

                    Response.Write("SQL Error: " + ex.Message);
                }

            }
        }
    }
}