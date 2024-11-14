using RAsio_Project.Controller;
using RAsio_Project.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAsio_Project.View
{
    public partial class CartUpdateView : System.Web.UI.Page
    {
        int stationeryID;
        String userID;
        CartViewData cv;
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            stationeryID = Int32.Parse(Request.QueryString["cID"]);
            userID = Session["UserID"] as string;
            cv = userController.getCartItem(int.Parse(userID), stationeryID);

            if (!IsPostBack)
            {
                nameLB.Text = cv.StationeryName;
                priceLB.Text = cv.StationeryPrice.ToString();
                quantityTB.Text = cv.Quantity.ToString();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String quantity = quantityTB.Text;
            String errorMessage = userController.updateCartValidation(quantity);
            if (!errorMessage.Equals(""))
            {
                errorMsg.Text = errorMessage;
                return;
            }
            userController.updateCartQuantity(cv.UserID, cv.StationeryID, int.Parse(quantity));
            Response.Redirect("CartView.aspx");
        }
    }
}