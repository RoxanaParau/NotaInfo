using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotaInfo.DAL;

namespace NotaInfo.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

      //  protected void btnLogin_Click(object sender, EventArgs e)
      //  {
         
      //      // Initialize FormsAuthentication, for what it's worth
      //      FormsAuthentication.Initialize();
      //      using (var context = new UniversityEntities())
      //      {
      //          var user = context.Users1.Where(u => u.Username == txtUserName.Text &&u. FormsAuthentication.HashPasswordForStoringInConfigFile(
      //txtPassword.Text, "md5"));
      //      }
      //  }

  
    }
}