using RAsio_Project.Handler;
using RAsio_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Controller
{
    public class StationeryController
    {
        StationeryHandler handler = new StationeryHandler();

        public String stationeryUpdateValidation(String name, String price, String oldName)
        {
            MsStationery sResult = getStationery(name);
            if (name.Equals("") || price.Equals(""))
            {
                return "Fill all fields!!";
            }
            else if (name.Length <= 3 || name.Length >= 50)
            {
                return "Name Lenght must be between 3 - 50 char";
            }
            else if (!priceIsDigit(price))
            {
                return "Input Price Correctly";
            }
            else if (int.Parse(price) < 2000)
            {
                return "Price must be greater or equal to 2000";
            }
            else if(sResult != null && !sResult.StationeryName.Equals(oldName))
            {
                return "That item is already in List";
            }
            else
            {
                return "";
            }

        }
        
        public String stationeryOrderValidation(int quantity)
        {
            if(quantity <= 0)
            {
                return "Quantity Must be greater than 0";
            }
            else
            {
                return "";
            }
        }

        public String stationeryInsertValidation(String name, String price)
        {
            MsStationery sResult = getStationery(name);
            if (name.Equals("") || price.Equals(""))
            {
                return "Fill all required Fields!!";
            }
            else if(name.Length <= 3 || name.Length >= 50)
            {
                return "Name Lenght must be between 3 - 50 char";
            }
            else if (!priceIsDigit(price))
            {
                return "Input Price Correctly!!";
            }
            else if (int.Parse(price) < 2000)
            {
                return "Price must be greater or equal 2000";
            }
            else if(sResult != null)
            {
                return "Item already Exist";
            }
            else
            {
                return "";
            }
        }

        public bool priceIsDigit(String price)
        {
            if (string.IsNullOrEmpty(price))
            {
                return false;
            }
            else if (price.StartsWith("0"))
            {
                return false;
            }

            foreach (char c in price)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public MsStationery getStationery(int id)
        {
            return handler.getStationery(id);
        }

        public MsStationery getStationery(string name)
        {
            return handler.getStationery(name);
        }

        public List<MsStationery> fetchAllStationery()
        {
            return handler.fetchAllStationery();
        }

        public void addStationery(String name, int price)
        {
            handler.addStationery(name, price);
            return;
        }

        public void updateStationery(int id, string name, int price)
        {
            handler.updateStationery(id, name, price);
            return;
        }

        public void deleteStationery(string name)
        {
            handler.deleteStationery(name);
            return;
        }

    }
}