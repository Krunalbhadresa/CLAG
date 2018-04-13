using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        span_pwdreset.InnerHtml = " ";
    }

    protected void btnSendLink_Click(object sender, EventArgs e)
    {
        span_pwdreset.InnerHtml = "Your password reset link has been sent to your email.";
    }
}