using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuggedOut
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            if (isValidID())
            {
                Response.Redirect("issueinfo.aspx?issueID=" + txtSearch.Text);
            }
            else
            {
                lblSearchError.Text = "Numbers only in the search box";
            }
        }

        private bool isValidID()
        {
            if (txtSearch.Text.Length < 1)
                return false;

            for (int i = 0; i < txtSearch.Text.Length; i++)
            {
                int c = txtSearch.Text[i];

                if (c < 48 || c > 57)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
