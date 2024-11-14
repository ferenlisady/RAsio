using RAsio_Project.Controller;
using RAsio_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAsio_Project.View
{
    public partial class LoginView : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["UserData"];
                if(userCookie != null)
                {
                    Session["UserID"] = userCookie["UserID"];
                    Session["UserRole"] = userCookie["UserRole"] as string;
                    Session.Timeout = 360;
                    Response.Redirect("HomeView.aspx", true);
                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {

            String username = UsernameTB.Text;
            String password = UserPasswordTB.Text;

            if(username.Equals("") || password.Equals(""))
            {
                errorMsg.Text = "Fill All required Field";
            }
            else
            {
                MsUser user = userController.getUser(username, password);
                if (user == null)
                {
                    errorMsg.Text = "Wrong Username or Password";
                    return;
                }
                if (RemembermeCB.Checked)
                {
                    HttpCookie userCookie = new HttpCookie("UserData");
                    userCookie["UserID"] = user.UserID.ToString();
                    userCookie["UserRole"] = user.UserRole;
                    userCookie.Expires = DateTime.Now.AddHours(48);
                    Response.Cookies.Add(userCookie);
                }
                Session["UserID"] = user.UserID.ToString();
                Session["UserRole"] = user.UserRole.ToString();
                Session.Timeout = 360;
                Response.Redirect("HomeView.aspx", true);
            }

        }
    }
}