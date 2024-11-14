using RAsio_Project.Factory;
using RAsio_Project.Model;
using RAsio_Project.Repository;
using RAsio_Project.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Handler
{
    public class TransactionHandler
    {

        TransactionRepository repo = TransactionRepository.getInstance();
        TransactionFactory transactionFactory = new TransactionFactory();

        public List<TDViewData> fetchTransactionDetail(int TransactionID)
        {
            return repo.fetchTransactionDetail(TransactionID);
        }
        public List<THViewData> fetchTransactionHeader(int userID)
        {
            return repo.fetchTransactionHeader(userID);
        }

        public List<THViewData> fetchAllTransactionHeader()
        {
            return repo.fetchAllTransactionHeader();
        }

        public void createTransaction(int userID, List<Cart> cartList)
        {
            TransactionHeader th = transactionFactory.createTH(userID);
            List<TransactionDetail> tdList = new List<TransactionDetail>();
            foreach(Cart cart in cartList)
            {
                TransactionDetail td = transactionFactory.createTD(cart.StationeryID, cart.Quantity);
                tdList.Add(td);
            }

            repo.createTransaction(th, tdList);
            return;
        }

    }
}