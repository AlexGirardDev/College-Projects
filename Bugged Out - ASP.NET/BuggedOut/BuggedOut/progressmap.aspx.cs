using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace BuggedOut
{
    public partial class progressmap : System.Web.UI.Page
    {
        SqlConnection connection;
        float Resolved;
        float Total;
        int sabPercent;
        int cc4Percent;
        int wpaPercent;
        int cohPercent;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr_BuggedOutDB"].ConnectionString);
            try
            {
                //Open Sql Connection
                connection.Open();

                //Counts total issues and saves as a variable for Call of Honor
                string countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE [projectName]='Call of Honor'";
                SqlCommand command = new SqlCommand(countString, connection);
                Total = Convert.ToInt32(command.ExecuteScalar());
                                
                //Counts resolved issues and saves as a variable for Call of Honor
                countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE ([status]='Resolved' OR [status]='Closed') AND [ProjectName]='Call of Honor'";
                command = new SqlCommand(countString, connection);
                Resolved = Convert.ToInt32(command.ExecuteScalar());
                
                //Calculate Call of Honor resolved ticket percentage for Call of Honor
                cohPercent = (int)((Resolved / Total) * 100);

                //Counts total issues and saves as a variable for World of Peacecraft
                countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE [projectName]='World of Peacecraft'";
                command = new SqlCommand(countString, connection);
                Total = Convert.ToInt32(command.ExecuteScalar());
                
                //Counts resolved issues and saves as a variable for World of Peacecraft
                countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE ([status]='Resolved' OR [status]='Closed') AND [ProjectName]='World of Peacecraft'";
                command = new SqlCommand(countString, connection);
                Resolved = Convert.ToInt32(command.ExecuteScalar());

                //Calculate Call of Honor resolved ticket percentage for World of Peacecraft
                wpaPercent = (int)((Resolved / Total) * 100);

                //Counts total issues and saves as a variable for Slightly Agitated Bovine
                countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE [projectName]='Slightly Agitated Bovine'";
                command = new SqlCommand(countString, connection);
                Total = Convert.ToInt32(command.ExecuteScalar());


                //Counts resolved issues and saves as a variable for Slightly Agitated Bovine
                countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE ([status]='Resolved' OR [status]='Closed') AND [ProjectName]='Slightly Agitated Bovine'";
                command = new SqlCommand(countString, connection);
                Resolved = Convert.ToInt32(command.ExecuteScalar());

                //Calculate Call of Honor resolved ticket percentage for Slightly Agitated Bovine
                sabPercent = (int)((Resolved / Total) * 100);

                //Counts total issues and saves as a variable CarCraft4
                countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE [projectName]='CarCraft 4'";
                command = new SqlCommand(countString, connection);
                Total = Convert.ToInt32(command.ExecuteScalar());


                //Counts resolved issues and saves as a variable for CarCraft4
                countString = "SELECT COUNT(issueId) FROM [tIssues] WHERE ([status]='Resolved' OR [status]='Closed') AND [ProjectName]='CarCraft 4'";
                command = new SqlCommand(countString, connection);
                Resolved = Convert.ToInt32(command.ExecuteScalar());

                //Calculate Call of Honor resolved ticket percentage for CarCraft4
                cc4Percent = (int)((Resolved / Total) * 100);
                
                //Close Sql Connection  
                connection.Close();

                //Set Progress Panel Widths
                pnlCoh.Style.Value = "width: " + cohPercent + "%";
                pnlWpa.Style.Value = "width: " + wpaPercent + "%";
                pnlSab.Style.Value = "width: " + sabPercent + "%";
                pnlCc4.Style.Value = "width: " + cc4Percent + "%";
            }
            catch(SqlException ex)
            {
                if (connection != null)
                {
                    connection.Close();
                }

                Response.Write("SQL Error: " + ex.ToString());
            }

        }
    }
}