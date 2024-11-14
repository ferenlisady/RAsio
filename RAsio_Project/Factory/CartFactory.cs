using RAsio_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Factory
{
    public class CartFactory
    {

        public Cart createCart(int userId, int stationeryId, int quantity)
        {
            Cart cart = new Cart();
            cart.UserID = userId;
            cart.StationeryID = stationeryId;
            cart.Quantity = quantity;
            return cart;
        }

    }
}