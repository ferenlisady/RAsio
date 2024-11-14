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
    public partial class HomeView : System.Web.UI.Page
    {
        StationeryController stationeryController = new StationeryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStationeryGV();
                SetColumnVisibility();
            }
        }

        private void BindStationeryGV()
        {
            StationeryGV.DataSource = stationeryController.fetchAllStationery();
            StationeryGV.DataBind();
        }

        private void SetColumnVisibility()
        {
            string userRole = Session["UserRole"] as string;

            if (!string.IsNullOrEmpty(userRole))
            {
                if (userRole.Equals("Admin"))
                {
                    AdminInsertLink.Controls.Add(new LiteralControl("<a class='form-button' href='StationeryInsertView.aspx'>Add Stationery</a>"));
                    StationeryGV.Columns[3].Visible = true;
                    StationeryGV.Columns[4].Visible = true;
                }
                else
                {
                    StationeryGV.Columns[3].Visible = false;
                    StationeryGV.Columns[4].Visible = false;
                }
            }
            else
            {
                StationeryGV.Columns[3].Visible = false;
                StationeryGV.Columns[4].Visible = false;
            }

        }

        protected void UpdateStationeryBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            MsStationery stationery = stationeryController.getStationery(gvr.Cells[1].Text);
            Response.Redirect("UpdateView.aspx?sID=" + stationery.StationeryID);
        }

        protected void DeleteStationeryBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            stationeryController.deleteStationery(gvr.Cells[1].Text);
            BindStationeryGV();
        }

        protected void DetailStationeryBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            MsStationery stationery = stationeryController.getStationery(gvr.Cells[1].Text);
            Response.Redirect("StationeryDetailView.aspx?sID=" + stationery.StationeryID);
        }
    }
}