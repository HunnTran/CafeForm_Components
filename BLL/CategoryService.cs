using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryService
    {
        public List<Category> GetAll()
        {
            using (var categoryList = new CategoryModel())
            {
                return categoryList.Categories.ToList();
            }
        }



        public List<Category> GetSpecificList(string CateID)
        {
            using (var item = new CategoryModel())
            {
                return item.Categories.Where(m => m.CategoryID == CateID).ToList();
            }
        }

        public Category FindByID(string id)
        {
            using (var idCate = new CategoryModel())
            {
                return idCate.Categories.SingleOrDefault(p => p.CategoryID == id);
            }
        }

        public Category FindByName(string name)
        {
            using (var nameCate = new CategoryModel())
            {
                return nameCate.Categories.SingleOrDefault(n => n.CategoryName.ToLower() == name.ToLower());
            }
        }


        public void InsertUpdate(Category c)
        {
            using (var forInsert = new CategoryModel())
            {
                forInsert.Categories.AddOrUpdate(c);
                forInsert.SaveChanges();
            }

        }
        public void DeleteUpdate(Category c)
        {
            using (var forDelete = new CategoryModel())
            {
                forDelete.Categories.Attach(c);
                forDelete.Categories.Remove(c);
                forDelete.SaveChanges();
            }
        }
    }

}
