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
    public partial class StationeryDetailView : System.Web.UI.Page
    {
        StationeryController stationeryController = new StationeryController();
        UserController userController = new UserController();
        int stationeryID;
        string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            stationeryID = int.Parse(Request.QueryString["sID"]);
            MsStationery stationery = stationeryController.getStationery(stationeryID);

            if (!IsPostBack)
            {

                idLabel.Text = "Item ID : " + stationeryID;
                nameLabel.Text = "Item Name : " + stationery.StationeryName;
                priceLabel.Text = "Item Price : " + stationery.StationeryPrice;
                quantityTB.Text = "0";

                String roles = Session["UserRole"] as string;
                if (roles != null)
                {
                    if (roles.Equals("Admin"))
                    {
                        hideCustomerLayout();
                    }
                    else
                    {
                        showCustomerLayout();
                    }
                }
                else
                {
                    hideCustomerLayout();
                }
            }
        }

        protected void orderBtn_Click(object sender, EventArgs e)
        {
            int itemQuantity = int.Parse(quantityTB.Text);
            String errorMessage = stationeryController.stationeryOrderValidation(itemQuantity);
            if (!errorMessage.Equals(""))
            {
                errorMsg.Text = errorMessage;
                return;
            }
            userId = Session["UserID"] as string;
            userController.addUserCart(int.Parse(userId), stationeryID, itemQuantity);
            Response.Redirect("HomeView.aspx");
        }

        private void hideCustomerLayout()
        {
            orderBtn.Visible = false;
            quantityLabel.Visible = false;
            quantityTB.Visible = false;
        }

        private void showCustomerLayout()
        {
            orderBtn.Visible = true;
            quantityLabel.Visible = true;
            quantityTB.Visible = true;
        }
    }
}