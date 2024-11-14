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
    public partial class TransactionView : System.Web.UI.Page
    {
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionData();
            }
        }

        protected void DetailTrBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Response.Redirect("TDView.aspx?tID=" + gvr.Cells[0].Text);
        }

        public void BindTransactionData()
        {
            String userID = Session["UserID"] as string;
            List<THViewData> thViewList = transactionController.fetchTransactionHeader(int.Parse(userID));
            TransactionHeaderGV.DataSource = thViewList;
            TransactionHeaderGV.DataBind();
        }
    }
}