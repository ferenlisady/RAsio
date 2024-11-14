using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAsio_Project.Model;
using RAsio_Project.ViewData;

namespace RAsio_Project.Repository
{
    public class UserRepository
    {

        RaisoDBEntities db = new RaisoDBEntities();
        private static class SingleTone
        {
            static SingleTone()
            {

            }
            internal static readonly UserRepository INSTANCE = new UserRepository();
        }

        public static UserRepository getInstance()
        {
            return SingleTone.INSTANCE;
        }

        public void checkoutCart(List<Cart> cartList)
        {
            foreach (Cart cart in cartList)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
            return;
        }

        public CartViewData getCartItem(int userID, int StationeryID)
        {
            CartViewData cartData = (from cart in db.Carts
                                     join stationery in db.MsStationeries on cart.StationeryID equals stationery.StationeryID
                                     where cart.UserID == userID && cart.StationeryID == StationeryID
                                     select new CartViewData
                                     {
                                         UserID = cart.UserID,
                                         StationeryID = cart.StationeryID,
                                         Quantity = cart.Quantity,
                                         StationeryName = stationery.StationeryName,
                                         StationeryPrice = stationery.StationeryPrice
                                     }).FirstOrDefault();
            return cartData;
        }

        public void removeCart(int userID, int StationeryID)
        {
            Cart existingCartItem = (from d in db.Carts where d.UserID == userID && d.StationeryID == StationeryID select d).FirstOrDefault();
            db.Carts.Remove(existingCartItem);
            db.SaveChanges();
        }

        public void updateCartQuantity(Cart cart)
        {
            Cart existingCartItem = db.Carts.Find(cart.UserID, cart.StationeryID);
            if(existingCartItem == null)
            {
                throw new ArgumentException("No Cart");
            }
            existingCartItem.Quantity = cart.Quantity;
            db.SaveChanges();
        }

        public List<CartViewData> fetchUserCart(int userID)
        {
            List<CartViewData> cartList = (from cart in db.Carts
                                   join stationery in db.MsStationeries on cart.StationeryID equals stationery.StationeryID
                                   where cart.UserID == userID
                                   select new CartViewData
                                   {
                                       UserID = cart.UserID,
                                       StationeryID = cart.StationeryID,
                                       Quantity = cart.Quantity,
                                       StationeryName = stationery.StationeryName,
                                       StationeryPrice = stationery.StationeryPrice
                                   }).ToList();
            return cartList;
        }

        public List<Cart> fetchUserCartObj(int userID)
        {
            List<Cart> cartList = (from cart in db.Carts where cart.UserID == userID select cart).ToList();
            return cartList;
        }

        public void addToCart(Cart cart)
        {
            Cart existingCartItem = (from d in db.Carts where d.UserID == cart.UserID && d.StationeryID == cart.StationeryID select d).FirstOrDefault();

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cart.Quantity;
            }
            else
            {
                db.Carts.Add(cart);
            }

            db.SaveChanges();
        }

        public MsUser getUser(String name, String password)
        {
            MsUser user = (from data in db.MsUsers where data.UserName == name && data.UserPassword == password select data).FirstOrDefault();

            return user;
        }

        public MsUser getUser(String name)
        {
            MsUser user = (from data in db.MsUsers where data.UserName == name select data).FirstOrDefault();

            return user;
        }

        public MsUser getUser(int id)
        {
            MsUser user = (from data in db.MsUsers where data.UserID == id select data).FirstOrDefault();

            return user;
        }

        public void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
            return;
        }

        public void updateUser(MsUser newUserData)
        {
            MsUser user = db.MsUsers.Find(newUserData.UserID);
            user.UserName = newUserData.UserName;
            user.UserPassword = newUserData.UserPassword;
            user.UserDOB = newUserData.UserDOB;
            user.UserPhone = newUserData.UserPhone;
            user.UserAddress = newUserData.UserAddress;
            user.UserGender = newUserData.UserGender;
            db.SaveChanges();
            return;
        }

    }
}