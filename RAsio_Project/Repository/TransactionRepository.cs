using RAsio_Project.Model;
using RAsio_Project.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Repository
{
    public class TransactionRepository
    {

        RaisoDBEntities db = new RaisoDBEntities();
        private static class SingleTone
        {
            static SingleTone()
            {

            }
            internal static readonly TransactionRepository INSTANCE = new TransactionRepository();
        }

        public static TransactionRepository getInstance()
        {
            return SingleTone.INSTANCE;
        }

        public List<TDViewData> fetchTransactionDetail(int TransactionID)
        {
            List<TDViewData> tdList = (from td in db.TransactionDetails
                                       join st in db.MsStationeries on td.StationeryID equals st.StationeryID
                                       where td.TransactionID == TransactionID
                                       select new TDViewData
                                       {
                                           StationeryID = st.StationeryID,
                                           StationeryName = st.StationeryName,
                                           StationeryPrice = st.StationeryPrice,
                                           Quantity = td.Quantity
                                       }).ToList();
            return tdList;
        }

        public List<THViewData> fetchTransactionHeader(int userID)
        {
            List<THViewData> thList = (from th in db.TransactionHeaders
                                       join user in db.MsUsers on th.UserID equals user.UserID
                                       where th.UserID == userID 
                                       select new THViewData
                                       {
                                           UserID = user.UserID,
                                           UserName = user.UserName,
                                           TransactionID = th.TransactionID,
                                           TransactionDate = th.TransactionDate
                                       }).ToList();
            return thList;
        }

        public List<THViewData> fetchAllTransactionHeader()
        {
            List<THViewData> thList = (from th in db.TransactionHeaders
                                       join user in db.MsUsers on th.UserID equals user.UserID
                                       select new THViewData
                                       {
                                           UserID = user.UserID,
                                           UserName = user.UserName,
                                           TransactionID = th.TransactionID,
                                           TransactionDate = th.TransactionDate
                                       }).ToList();
            return thList;
        }

        public void createTransaction(TransactionHeader th, List<TransactionDetail> tdList)
        {
            db.TransactionHeaders.Add(th);
            db.SaveChanges();

            foreach(TransactionDetail td in tdList)
            {
                td.TransactionID = th.TransactionID;
                db.TransactionDetails.Add(td);
            }
            db.SaveChanges();
        }

    }
}