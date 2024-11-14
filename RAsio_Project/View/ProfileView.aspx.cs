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
    public partial class ProfileView : System.Web.UI.Page
    {
        UserController userController = new UserController();
        String userID;
        String oldUsername;
        MsUser user;
        protected void Page_Load(object sender, EventArgs e)
        {

            userID = Session["UserID"] as string;
            user = userController.getUser(int.Parse(userID));

            if (!IsPostBack)
            {

                oldUsername = user.UserName;
                UsernameTB.Text = user.UserName;
                UserPasswordTB.Text = user.UserPassword;
                UserDOB.Value = user.UserDOB.ToString();
                UserAddressTA.Value = user.UserAddress;
                PhoneNumberTB.Text = user.UserPhone;
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {

            String username = UsernameTB.Text;
            String password = UserPasswordTB.Text;
            DateTime dob = DateTime.Now;
            DateTime.TryParse(UserDOB.Value, out dob);
            String gender = GenderRBList.SelectedValue;
            String address = UserAddressTA.Value;
            String phoneNumber = PhoneNumberTB.Text;

            String errorMessage = userController.userUpdateValidation(username, dob, gender, password, address, phoneNumber, user.UserName);

            if (!errorMessage.Equals(""))
            {
                errorMsg.Text = errorMessage;
                return;
            }
            else
            {
                userController.updateUser(user.UserID, username, dob, gender, user.UserRole,password, address, phoneNumber);
                Response.Redirect("ProfileView.aspx");
            }
        }
    }
}