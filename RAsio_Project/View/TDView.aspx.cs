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
    public partial class TDView : System.Web.UI.Page
    {

        TransactionController transactionController = new TransactionController();
        int thID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                thID = int.Parse(Request.QueryString["tID"]);
                BindTD();
            }
        }

        private void BindTD()
        {
            List<TDViewData> tdViewList = transactionController.fetchTransactionDetail(thID);
            TransactionDetailGV.DataSource = tdViewList;
            TransactionDetailGV.DataBind();
        }

    }
}