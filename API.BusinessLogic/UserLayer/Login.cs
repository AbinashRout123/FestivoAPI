using API.DataAccessLayer;
using API.Models;
using API.Models.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.BusinessLogic
{
    public class Login
    {
        FestivoDBContext Db = new FestivoDBContext();
        public bool EmailValid(Users model)
        {
            var query = Db.users.Where(x => x.Email == model.Email).FirstOrDefault();
            if (query != null)
                return true;
            else
                return false;
        }

        public int login(Users model)
        {
            if (EmailValid(model))
            {
                var query = Db.users.Where(x => x.Email == model.Email).FirstOrDefault();
                if (query == null)
                {
                    return 0;
                }
                else
                {
                   
                    if (query.Role.ToUpper() == "USER")
                    {
                        
                        var pass = query.Password;
                        if (model.Password != pass)
                            return 0;
                        else
                            return 1;
                    }
                    else
                    {
                        var pass = query.Password;
                        if (model.Password != pass)
                            return 0;
                        else
                            return 2;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        public string Role(string email)
        {
            var role = (from user in Db.users
                       where user.Email == email
                       select user.Role).FirstOrDefault();
            return role;
        }

        public string getUserName(int id)
        {
            var query = Db.users.Where(x => x.UserId == id).FirstOrDefault();
            return query.FirstName;
        }
        
       public bool socialLogin(Users user)
        {
            var query = Db.users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (query != null)
                return true;
            else
                return false;

        }

        public int getUserId(Users model)
        {
            var query = Db.users.Where(x => x.Email == model.Email).FirstOrDefault();
            return query.UserId;
        }
    }

}
