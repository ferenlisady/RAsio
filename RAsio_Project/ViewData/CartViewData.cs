using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.ViewData
{
    public class CartViewData
    {
        public int UserID { get; set; }
        public int StationeryID { get; set; }
        public int Quantity { get; set; }
        public string StationeryName { get; set; }
        public decimal StationeryPrice { get; set; }

    }
}