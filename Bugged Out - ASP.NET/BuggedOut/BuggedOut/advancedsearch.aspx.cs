using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Specialized;

namespace BuggedOut
{
    public partial class advancedSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResults.Text = "";
            NameValueCollection nvc = Request.QueryString;
            //Checks if the View issues pages redirected back here with queryString Resultsfound = 0
            for (int i = 0; i < nvc.Count; i++)
            {
                if (nvc.GetKey(0).Equals("resultsfound") && nvc.Get(0).Equals("0"))
                {
                    lblResults.Text = "No results found";
                }
            }
        }

        protected void cmdASearch_Click(object sender, EventArgs e)
        {
            //Create query string NVC 
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            //Get input fields and add them to query string
            if( !drpLstProjName.SelectedItem.Text.Equals("Any"))
            {
                queryString["projectName"] = drpLstProjName.SelectedItem.Text;
            }
            if (txtCreatedBy.Text.Length != 0)
            {
                queryString["createdBy"] = txtCreatedBy.Text;
            }
            if (txtAssignedTo.Text.Length != 0)
            {
                queryString["assignedTo"] = txtAssignedTo.Text;
            }
            if (!drpLstCategory.SelectedItem.Text.Equals("Any"))
            {
                queryString["category"] = drpLstCategory.SelectedItem.Text;
            }
            if (!drpLstPriority.SelectedItem.Text.Equals("Any"))
            {
                queryString["priority"] = drpLstPriority.SelectedItem.Text;
            }
            if (!drpLstStatus.SelectedItem.Text.Equals("Any"))
            {
                queryString["status"] = drpLstStatus.SelectedItem.Text;
            }
            if (txtIssuesTitle.Text.Length != 0)
            {
                queryString["issueTitle"] = txtIssuesTitle.Text;
            }

            if (queryString.ToString().Length == 0)
            {
                Response.Redirect("viewissues.aspx");
            }
            else
            {
                Response.Redirect("viewissues.aspx?" + queryString.ToString());
            }
        }
    }
}