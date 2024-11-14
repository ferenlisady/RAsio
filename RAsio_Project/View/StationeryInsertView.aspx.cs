using RAsio_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAsio_Project.View
{
    public partial class StationeryInsertView : System.Web.UI.Page
    {
        StationeryController stationeryController = new StationeryController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            String sName = nameTB.Text;
            String sPrice = priceTB.Text;
            String errorMessage = stationeryController.stationeryInsertValidation(sName, sPrice);

            if (!errorMessage.Equals(""))
            {
                errorMsg.Text = errorMessage;
                return;
            }
            else
            {
                stationeryController.addStationery(sName, int.Parse(sPrice));
                Response.Redirect("HomeView.aspx");
            }
        }
    }
}