using RAsio_Project.Handler;
using RAsio_Project.Model;
using RAsio_Project.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Controller
{
    public class TransactionController
    {
        TransactionHandler handler = new TransactionHandler();

        public List<THViewData> fetchAllTransactionHeader()
        {
            return handler.fetchAllTransactionHeader();
        }
        public List<TDViewData> fetchTransactionDetail(int TransactionID)
        {
            return handler.fetchTransactionDetail(TransactionID);
        }
        public List<THViewData> fetchTransactionHeader(int userID)
        {
            return handler.fetchTransactionHeader(userID);
        }
        public void createTransaction(int userID, List<Cart> cartList)
        {
            handler.createTransaction(userID, cartList);
            return;
        }

    }
}