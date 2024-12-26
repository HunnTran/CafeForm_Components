using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace BLL
{
    public class UserService
    {
        public List<User> GetAll()
        {
            using (var employeeList = new Model1())
            {
                return employeeList.Users.ToList();
            }
            
        }
        
      
        public List<User> GetSpecificList(string roleid)
        {
            using(var person = new Model1())
            {
                return person.Users.Where(m => m.RoleID == roleid).ToList();
            }
        }

        public User FindByID(string id)
        {
            using (var idEmploy = new Model1())
            {
                return idEmploy.Users.SingleOrDefault(p => p.IdentityCard == id);
            }
        }

        public User FindByName(string name)
        {
            using (var nameEmploy = new Model1())
            {
                return nameEmploy.Users.SingleOrDefault(n => n.FullName.ToLower() == name.ToLower());
            }
        }


        public void InsertUpdate(User e)    
        {
            using (var forInsert = new Model1())
            {
                forInsert.Users.AddOrUpdate(e);
                forInsert.SaveChanges();
            }
            
        }
        public void DeleteUpdate(User e)
        {
            using (var forDelete = new Model1())
            {
                forDelete.Users.Attach(e);
                forDelete.Users.Remove(e);
                forDelete.SaveChanges();
            }
        }
    }
}
