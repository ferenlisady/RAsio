using RAsio_Project.Controller;
using RAsio_Project.Model;
using RAsio_Project.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAsio_Project.View
{
    public partial class CartView : System.Web.UI.Page
    {
        UserController userController = new UserController();
        TransactionController transactionController = new TransactionController();
        String UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartGV();
            }
        }

        protected void UpdateCartBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Response.Redirect("CartUpdateView.aspx?cID=" + gvr.Cells[0].Text);
        }

        protected void RemoveCartItemBtn_Click(object sender, EventArgs e)
        {
            UserId = Session["UserID"] as string;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            userController.removeCart(int.Parse(UserId), int.Parse(gvr.Cells[0].Text));
            BindCartGV();
        }

        private void BindCartGV()
        {
            UserId = Session["UserID"] as string;
            List<CartViewData> cartList = userController.fetchUserCart(int.Parse(UserId));
            CartGV.DataSource = cartList;
            CartGV.DataBind();
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            UserId = Session["UserID"] as string;
            List<Cart> cartList = userController.fetchUserCartObj(int.Parse(UserId));

            if (cartList.Count == 0) return;

            transactionController.createTransaction(int.Parse(UserId), cartList);
            userController.checkoutCart(cartList);
            BindCartGV();
        }
    }
}