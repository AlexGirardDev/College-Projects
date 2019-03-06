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
    public partial class viewissues : System.Web.UI.Page
    {
        SqlConnection connection = null;
        int issueID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Query strings and store them in a NVC
            NameValueCollection qsValues = Request.QueryString;


            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr_BuggedOutDB"].ConnectionString);


            try
            {
                //Connect to SQL server
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;


                string sqlcommand = "SELECT [issueID],[issueTitle],[projectName],[category],[status],[priority] FROM [tIssues]";
                //Generate sql command dynammicaly based on query strings

                for (int i = 0; i < qsValues.Count; i++)
                {
                    if (i == 0)
                    {
                        sqlcommand += " WHERE [" + qsValues.GetKey(i) + "] = '" + qsValues.Get(i) + "'"; ;

                    }
                    else
                    {
                        sqlcommand += " AND [" + qsValues.GetKey(i) + "] = '" + qsValues.Get(i) + "'";

                    }
                }

                command.CommandText = sqlcommand;
                //execute sql command and get data in dataReader
                SqlDataReader dr = command.ExecuteReader();

                if (!dr.HasRows)
                {
                    //if no results found redirect to advanced search
                    Response.Redirect("advancedsearch.aspx?resultsfound=0");

                }

                gv1.DataSource = dr;
                gv1.DataBind();

                //Color rows based on Issues status
                for (int i = 0; i < gv1.Rows.Count; i++)
                {
                    string status = gv1.Rows[i].Cells[5].Text;

                    if (status.Equals("Open"))
                    {
                        gv1.Rows[i].BackColor = System.Drawing.Color.FromArgb(212, 83, 84);
                    }
                    else if (status.Equals("Acknowledged"))
                    {
                        gv1.Rows[i].BackColor = System.Drawing.Color.FromArgb(47, 202, 216);
                    }
                    else if (status.Equals("Resolved"))
                    {
                        gv1.Rows[i].BackColor = System.Drawing.Color.FromArgb(169, 220, 58);
                    }
                    else if (status.Equals("Closed"))
                    {
                        gv1.Rows[i].BackColor = System.Drawing.Color.FromArgb(129, 139, 133);
                    }
                }
                //Close connections
                connection.Close();

            }
            catch (SqlException ex)
            {
                //handle exceptions
                
                if (connection != null)
                {
                    connection.Close();
                }

                Response.Write("SQL Error: " + ex.Message);
            }

        }
    }
}
