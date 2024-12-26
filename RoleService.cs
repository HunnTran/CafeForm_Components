using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
        public class RoleService
        {
            public List<Role> GetAll()
            {
                using (var roleList = new Model1())
                {
                return roleList.Roles.ToList();

                }
            }



            public void InsertUpdate(Role r)
            {
                using (var forInsert = new Model1())
                {
                forInsert.Roles.AddOrUpdate(r);
                forInsert.SaveChanges();
                }
            
        }

            public void DeleteUpdate(Role r)
            {
                using (var forDelete = new Model1())
                {
                    forDelete.Roles.Remove(r);
                    forDelete.SaveChanges();
                }
            
            }

            public void EditUpdate(Role r)
            {
                using (Model1 forEdit = new Model1())
                {
                    var existingRole = forEdit.Roles.FirstOrDefault(x => x.RoleID == r.RoleID);
                    if (existingRole != null)
                    {
                        existingRole.RoleName = r.RoleName;
                        forEdit.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Chức vụ không tồn tại");
                    }
                }
            }
        }
}
