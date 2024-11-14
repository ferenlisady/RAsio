using RAsio_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Repository
{
    public class StationeryRepository
    {

        RaisoDBEntities db = new RaisoDBEntities();
        private static class SingleTone
        {
            static SingleTone()
            {

            }
            internal static readonly StationeryRepository INSTANCE = new StationeryRepository();
        }

        public static StationeryRepository getInstance()
        {
            return SingleTone.INSTANCE;
        }

        public MsStationery getStationery(int id)
        {
            MsStationery stationery = (from data in db.MsStationeries where data.StationeryID.Equals(id) select data).FirstOrDefault();
            return stationery;
        }

        public MsStationery getStationery(string name)
        {
            MsStationery stationery = (from data in db.MsStationeries where data.StationeryName.Equals(name) select data).FirstOrDefault();
            return stationery;
        }

        public List<MsStationery> fetchAllStationery()
        {
            List<MsStationery> stationeryList = (from data in db.MsStationeries select data).ToList();
            return stationeryList;
        }

        public void addStationery(MsStationery stationery)
        {
            db.MsStationeries.Add(stationery);
            db.SaveChanges();
            return;
        }

        public void updateStationery(MsStationery newStationery)
        {
            MsStationery stationery = db.MsStationeries.Find(newStationery.StationeryID);
            stationery.StationeryName = newStationery.StationeryName;
            stationery.StationeryPrice = newStationery.StationeryPrice;
            db.SaveChanges();
            return;
        }

        public void deleteStationery(string name)
        {
            MsStationery toDelete = getStationery(name);
            MsStationery stationery = db.MsStationeries.Find(toDelete.StationeryID);
            db.MsStationeries.Remove(stationery);
            db.SaveChanges();
            return;
        }

    }
}