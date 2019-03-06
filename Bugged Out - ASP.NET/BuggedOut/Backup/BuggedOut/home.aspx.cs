using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BuggedOut
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> issueIDs = (List<int>)Session["issuesMade"];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr_BuggedOutDB"].ConnectionString);

            string sql = "";

            if (issueIDs == null)
            {
                lblNotFound.Text = "<br />You have not created any issues this session.<br /><br />";
                gridViewYourIssues.Visible = false;
            }
            else
            {
                sql = "SELECT [issueID], [issueTitle] FROM [tIssues] WHERE issueID IN (";

                for (int i = 0; i < issueIDs.Count - 1; i++)
                {
                    sql += (issueIDs[i] + ", ");
                }

                sql += (issueIDs[issueIDs.Count - 1] + ")");

                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;

                    SqlDataReader dr = cmd.ExecuteReader();

                    gridViewYourIssues.DataSource = dr;
                    gridViewYourIssues.DataBind();

                    conn.Close();
                }
                catch (SqlException ex)
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }

                    Response.Write("SQL Error: " + ex.Message);
                }
            }

            sql = "SELECT TOP 5 [issueID], [issueTitle] FROM [tIssues] ORDER BY [lastUpdate] DESC";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand {Connection = conn, CommandText = sql};

                SqlDataReader dr = cmd.ExecuteReader();

                gridViewRecentUpdates.DataSource = dr;
                gridViewRecentUpdates.DataBind();

                conn.Close();
            }
            catch (SqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                }

                Response.Write("SQL Error: " + ex.Message);
            }
            
        }
    }
}