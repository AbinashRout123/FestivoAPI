using API.DataAccessLayer;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.BusinessLogic
{
    public class Register
    {

        FestivoDBContext db = new FestivoDBContext();
        public bool DataAdd(Users model)
        {
            var query = db.users.Where(x => x.Email == model.Email).FirstOrDefault();
            if (query == null)
            {
                model.Role = "user";
                db.users.Add(model);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Users> GetData()
        {
            return db.users;
        }

        public Users GetDataById(int id)
        {
            var query = (from r in db.users where r.UserId == id select r).FirstOrDefault();
            return query;
        }

        public bool updateData(int id, Users model)
        {
            if (DataValid(id))
            {
                var query = db.users.Where(z => z.UserId == id).FirstOrDefault();
                query.FirstName = model.FirstName;
                query.LastName = model.LastName;
                query.Email = model.Email;
                query.Password = model.Password;
                query.Contact = model.Contact;
                query.Gender = model.Gender;
                // db.Users.Attach(model);
                // db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool deleteData(int id)
        {
            if (DataValid(id))
            {
                var query = db.users.Where(z => z.UserId == id).FirstOrDefault();
                db.Entry(query).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean DataValid(int id)
        {
            var query = db.users.Where(z => z.UserId == id).FirstOrDefault();
            if (query == null)
                return false;
            else
                return true;
        }

        public bool EditProfile(int id, Users model)
        {
            if (DataValid(id))
            {
                var query = db.users.Where(z => z.UserId == id).FirstOrDefault();
                query.FirstName = model.FirstName;
                query.LastName = model.LastName;
                query.Email = model.Email;
                query.Password = model.Password;
                query.Contact = model.Contact;
                
                // db.Users.Attach(model);
                // db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}






