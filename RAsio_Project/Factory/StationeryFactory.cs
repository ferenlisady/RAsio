using RAsio_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Factory
{
    public class StationeryFactory
    {

        public MsStationery createStationery(String name, int price)
        {
            MsStationery stationery = new MsStationery();
            stationery.StationeryName = name;
            stationery.StationeryPrice = price;
            return stationery;
        }

        public MsStationery createStationery(int id, String name, int price)
        {
            MsStationery stationery = new MsStationery();
            stationery.StationeryID = id;
            stationery.StationeryName = name;
            stationery.StationeryPrice = price;
            return stationery;
        }

    }
}