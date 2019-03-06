using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace BuggedOut
{
    public partial class nosissuesfound : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection nvc = Request.QueryString;
            string str_issueID = nvc.Get("issueID");

            if (str_issueID == null)
                Response.Redirect("home.aspx");

            lblErrorLabel.Text = "Issue with ID: '" + str_issueID + "' was not found.";
        }
    }
}