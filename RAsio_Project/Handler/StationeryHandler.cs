using RAsio_Project.Factory;
using RAsio_Project.Model;
using RAsio_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Handler
{
    public class StationeryHandler
    {

        StationeryRepository repo = StationeryRepository.getInstance();
        StationeryFactory stationeryFactory = new StationeryFactory();

        public MsStationery getStationery(int id)
        {
            return repo.getStationery(id);
        }

        public MsStationery getStationery(string name)
        {
            return repo.getStationery(name);
        }

        public List<MsStationery> fetchAllStationery()
        {
            return repo.fetchAllStationery();
        }

        public void addStationery(String name, int price)
        {
            MsStationery stationery = stationeryFactory.createStationery(name, price);
            repo.addStationery(stationery);
            return;
        }

        public void updateStationery(int id, string name, int price)
        {
            MsStationery stationery = stationeryFactory.createStationery(id, name, price);
            repo.updateStationery(stationery);
            return;
        }

        public void deleteStationery(string name)
        {
            repo.deleteStationery(name);
            return;
        }

    }
}