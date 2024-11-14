using RAsio_Project.Controller;
using RAsio_Project.CR;
using RAsio_Project.DataSet;
using RAsio_Project.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAsio_Project.View
{
    public partial class TrReportView : System.Web.UI.Page
    {
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            TrReportViewer.ReportSource = report;
            TransactionReport dataTR = getData(transactionController.fetchAllTransactionHeader());
            report.SetDataSource(dataTR);
        }

        private TransactionReport getData(List<THViewData> thList)
        {

            TransactionReport data = new TransactionReport();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (THViewData t in thList)
            {

                List<TDViewData> tdList = transactionController.fetchTransactionDetail(t.TransactionID);

                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["GrandTotal"] = getGrandTotal(t, tdList);
                headerTable.Rows.Add(hrow);

                foreach(TDViewData td in tdList)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = t.TransactionID;
                    drow["StationeryName"] = td.StationeryName;
                    drow["StationeryPrice"] = td.StationeryPrice;
                    drow["Quantity"] = td.Quantity;
                    drow["SubTotal"] = td.Quantity * td.StationeryPrice;
                    detailTable.Rows.Add(drow);
                }
            }
            return data;
        }

        private int getGrandTotal(THViewData th, List<TDViewData> tdList)
        {
            int gTotal = 0;
            foreach(TDViewData td in tdList)
            {
                gTotal += td.Quantity * td.StationeryPrice;
            }
            return gTotal;
        }
    }
}