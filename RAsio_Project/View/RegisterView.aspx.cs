using RAsio_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAsio_Project.View
{
    public partial class RegisterView : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserDOB.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd");
                UserDOB.Value = DateTime.Today.ToString("yyyy-MM-dd");
            }

            HttpCookie userCookie = Request.Cookies["UserData"];
            if (userCookie != null)
            {
                Session["UserID"] = userCookie["UserID"];
                Session["UserRole"] = userCookie["UserRole"] as string;
                Session.Timeout = 360;
                Response.Redirect("HomeView.aspx", true);
            }

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
          

            String username = UsernameTB.Text;
            String password = UserPasswordTB.Text;
            DateTime dob = DateTime.Now;
            DateTime.TryParse(UserDOB.Value, out dob);
            String gender = GenderRBList.SelectedValue;
            String address = UserAddressTA.Value;
            String phoneNumber = PhoneNumberTB.Text;

            String errorMessage = userController.userInputValidation(username, dob, gender, password, address, phoneNumber);

            if (!errorMessage.Equals(""))
            {
                errorMsg.Text = errorMessage;
            }
            else
            {
                userController.addUser(username, dob, gender, password, address, phoneNumber);
                Response.Redirect("LoginView.aspx");    
            }

        }
    }
}