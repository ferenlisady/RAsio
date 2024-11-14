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
    public partial class UpdateView : System.Web.UI.Page
    {
        StationeryController stationeryController = new StationeryController();
        int stationeryID;
        String oldName;
        protected void Page_Load(object sender, EventArgs e)
        {
            stationeryID = Int32.Parse(Request.QueryString["sID"]);
            MsStationery stationery = stationeryController.getStationery(stationeryID);

            if (!IsPostBack)
            {
                idLabel.Text = "Item ID : " + stationeryID;
                nameTB.Text = stationery.StationeryName;
                priceTB.Text = stationery.StationeryPrice.ToString();
            }
            oldName = stationery.StationeryName;
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String stationaryName = nameTB.Text;
            String stationaryPrice = priceTB.Text;
            String errorMessage = stationeryController.stationeryUpdateValidation(stationaryName, stationaryPrice, oldName);
            if (!errorMessage.Equals(""))
            {
                errorMsg.Text = errorMessage;
                return;
            }

            stationeryController.updateStationery(stationeryID, stationaryName, int.Parse(stationaryPrice));
            Response.Redirect("HomeView.aspx");
            return;
        }
    }
}