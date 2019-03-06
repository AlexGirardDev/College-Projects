using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BuggedOut
{
    [WebService(Namespace = "http://buggedout.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class StringTrimWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string TrimString(string inStr, int trimAmount)
        {
            if (inStr.Length <= trimAmount)
            {
                return inStr;
            }
            else
            {
                return (inStr.Substring(0, trimAmount) + "...");
            }
        }
    }
}
