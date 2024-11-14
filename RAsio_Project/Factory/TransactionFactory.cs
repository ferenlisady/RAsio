using RAsio_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Factory
{
    public class TransactionFactory
    {

        public TransactionHeader createTH(int UserID)
        {
            TransactionHeader th = new TransactionHeader();
            th.UserID = UserID;
            th.TransactionDate = DateTime.Now;
            return th;
        }

        public TransactionDetail createTD(int StationeryID, int Quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.StationeryID = StationeryID;
            td.Quantity = Quantity;
            return td;
        }

    }
}