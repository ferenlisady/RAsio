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
    public class UserHandler
    {
        UserRepository repo = UserRepository.getInstance();
        UserFactory userFactory = new UserFactory();
        CartFactory cartFactory = new CartFactory();


        public List<Cart> fetchUserCartObj(int userID)
        {
            return repo.fetchUserCartObj(userID);
        }
        public void checkoutCart(List<Cart> cartList)
        {
            repo.checkoutCart(cartList);
        }
        public CartViewData getCartItem(int userID, int StationeryID)
        {
            return repo.getCartItem(userID, StationeryID);
        }
        public void removeCart(int userID, int StationeryID)
        {
            repo.removeCart(userID, StationeryID);
            return;
        }

        public void updateCartQuantity(int userId, int stationeryId, int quantity)
        {
            Cart cart = cartFactory.createCart(userId, stationeryId, quantity);
            repo.updateCartQuantity(cart);
            return;
        }
        public void addUserCart(int userId, int stationeryId, int quantity)
        {
            Cart cart = cartFactory.createCart(userId, stationeryId, quantity);
            repo.addToCart(cart);
            return;
        }

        public List<CartViewData> fetchUserCart(int userID)
        {
            return repo.fetchUserCart(userID);
        }

        public MsUser getUser(String name, String password)
        {
            return repo.getUser(name, password);
        }

        public MsUser getUser(String name)
        {
            return repo.getUser(name);
        }

        public MsUser getUser(int id)
        {
            return repo.getUser(id);
        }

        public void addUser(string name, DateTime dob, string gender, string role, string password, string address, string phone)
        {
            repo.addUser(userFactory.createUser(name, dob, gender, role, password, address, phone));
        }

        public void updateUser(int id, string name, DateTime dob, string gender, string role, string password, string address, string phone)
        {

            MsUser newUserData = userFactory.createUser(id, name, dob, gender, role, password, address, phone);
            repo.updateUser(newUserData);
            return;

        }


    }
}