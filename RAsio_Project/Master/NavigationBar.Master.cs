using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAsio_Project.Master
{
    public partial class NavigationBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetAuthorization();
        }

        public void SetAuthorization()
        {
            String roles = Session["UserRole"] as string;
            if (roles != null)
            {
                if (roles.Equals("Admin"))
                {
                    LogOutBtn.Visible = true;
                    AddAdminLinks();
                }
                else if (roles.Equals("Customer"))
                {
                    LogOutBtn.Visible = true;
                    AddCustomerLinks();
                }
                else
                {
                    LogOutBtn.Visible = false;
                    AddGuestLinks();
                }
            }
            else
            {
                LogOutBtn.Visible = false;
                AddGuestLinks();
            }
        }

        private void AddGuestLinks()
        {
            GuestLinks.Controls.Add(new LiteralControl("<a href='LoginView.aspx'>Login</a>"));
            GuestLinks.Controls.Add(new LiteralControl("<a href='RegisterView.aspx'>Register</a>"));
        }

        private void AddCustomerLinks()
        {
            CustomerLinks.Controls.Add(new LiteralControl("<a href='CartView.aspx'>Cart</a>"));
            CustomerLinks.Controls.Add(new LiteralControl("<a href='TransactionView.aspx'>Transaction</a>"));
            CustomerLinks.Controls.Add(new LiteralControl("<a href='ProfileView.aspx'>Update Profile</a>"));
        }

        private void AddAdminLinks()
        {
            AdminLinks.Controls.Add(new LiteralControl("<a href='TrReportView.aspx'>Transaction Report</a>"));
            AdminLinks.Controls.Add(new LiteralControl("<a href='ProfileView.aspx'>Update Profile</a>"));
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            if(Response.Cookies["UserData"] != null)
            {
                Response.Cookies["UserData"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("LoginView.aspx");
        }
    }
}