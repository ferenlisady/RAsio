using RAsio_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAsio_Project.Factory
{
    public class UserFactory
    {

        public MsUser createUser(string name, DateTime dob, string gender, string role, string password, string address, string phone)
        {
            MsUser user = new MsUser();
            user.UserName = name;
            user.UserGender = gender;
            user.UserDOB = dob;
            user.UserPassword = password;
            user.UserAddress = address;
            user.UserPhone = phone;
            user.UserRole = role;
            return user;
        }

        public MsUser createUser(int id, string name, DateTime dob, string gender, string role, string password, string address, string phone)
        {
            MsUser user = new MsUser();
            user.UserID = id;
            user.UserName = name;
            user.UserGender = gender;
            user.UserDOB = dob;
            user.UserPassword = password;
            user.UserAddress = address;
            user.UserPhone = phone;
            user.UserRole = role;
            return user;
        }

    }
}