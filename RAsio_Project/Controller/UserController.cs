using RAsio_Project.Handler;
using RAsio_Project.Model;
using RAsio_Project.ViewData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace RAsio_Project.Controller
{
    public class UserController
    {
        UserHandler handler = new UserHandler();

        public string updateCartValidation(string quantity)
        {
            if (!IsDigit(quantity))
            {
                return "Please input Digit Only";
            }
            else if (int.Parse(quantity) <= 0)
            {
                return "Quantity Must be bigger than 0";
            }
            else
            {
                return "";
            }
        }

        public string userInputValidation(string name, DateTime dob, string gender, string password, string address, string phone)
        {
            if (name.Equals(""))
            {
                return "Username can't be empty";
            }
            else if (name.Length <= 5 || name.Length >= 50)
            {
                return "Username Length Must be between 5 and 50";
            }
            else if (DateTime.Now.Year - dob.Year < 1)
            {
                return "DOB must be atleast 1 year age";
            }
            else if (address.Equals(""))
            {
                return "Address can't be empty";
            }
            else if (password.Equals(""))
            {
                return "Password can't be empty";
            }
            else if (!AlphanumericPassword(password))
            {
                return "Password must be alphanumeric";
            }
            else if (phone.Equals(""))
            {
                return "Phone number can't be empty";
            }
            else if (!NumericPhone(phone))
            {
                return "Phone number must be a digit only";
            }
            else if (!uniqueUser(name))
            {
                return "Username already taken!!";
            }
            else
            {
                return "";
            }
        }

        public string userUpdateValidation(string name, DateTime dob, string gender, string password, string address, string phone, string oldName)
        {

            if (name.Equals(""))
            {
                return "Username can't be empty";
            }
            else if (name.Length <= 5 || name.Length >= 50)
            {
                return "Username Length Must be between 5 and 50";
            }
            else if (DateTime.Now.Year - dob.Year < 1)
            {
                return "DOB must be atleast 1 year age";
            }
            else if (address.Equals(""))
            {
                return "Address can't be empty";
            }
            else if (password.Equals(""))
            {
                return "Password can't be empty";
            }
            else if (!AlphanumericPassword(password))
            {
                return "Password must be alphanumeric";
            }
            else if (phone.Equals(""))
            {
                return "Phone number can't be empty";
            }
            else if (!NumericPhone(phone))
            {
                return "Phone number must be a digit only";
            }
            else if (!uniqueUserUpdate(name, oldName))
            {
                return "Username already taken!!";
            }
            else
            {
                return "";
            }
        }

        public bool AlphanumericPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                if (hasLetter && hasDigit)
                {
                    return true;
                }
            }
            return hasLetter && hasDigit;
        }

        public bool NumericPhone(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public bool uniqueUser(string username)
        {
            MsUser user = handler.getUser(username);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool uniqueUserUpdate(string username, string oldname)
        {
            MsUser user = handler.getUser(username);
            if (user == null || username == oldname)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDigit(String number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            else if (number.StartsWith("0"))
            {
                return false;
            }

            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public List<Cart> fetchUserCartObj(int userID)
        {
            return handler.fetchUserCartObj(userID);
        }
        public void checkoutCart(List<Cart> cartList)
        {
            handler.checkoutCart(cartList);
        }

        public CartViewData getCartItem(int userID, int StationeryID)
        {
            return handler.getCartItem(userID, StationeryID);
        }
        public void removeCart(int userID, int StationeryID)
        {
            handler.removeCart(userID, StationeryID);
            return;
        }

        public void updateCartQuantity(int userId, int stationeryId, int quantity)
        {
            handler.updateCartQuantity(userId, stationeryId, quantity);
            return;
        }

        public void addUserCart(int userId, int stationeryId, int quantity)
        {
            handler.addUserCart(userId, stationeryId, quantity);
            return;
        }

        public MsUser getUser(int id)
        {
            return handler.getUser(id);
        }

        public List<CartViewData> fetchUserCart(int userID)
        {
            return handler.fetchUserCart(userID);
        }

        public MsUser getUser(string username, string password)
        {
            return handler.getUser(username, password);
        }

        public void addUser(string name, DateTime dob, string gender, string password, string address, string phone)
        {
            handler.addUser(name, dob, gender, "Customer", password, address, phone);
            return;
        }

        public void updateUser(int id, string name, DateTime dob, string gender, string role, string password, string address, string phone)
        {

            handler.updateUser(id, name, dob, gender, role,password, address, phone);
            return;

        }
    }
}