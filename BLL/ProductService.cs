using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductService
    {
        public List<Product> GetAll()
        {
            using (var productList = new CategoryModel())
            {
                return productList.Products.ToList();
            }
        }

        public List<Product> GetListByID(string byID)
        {
            using (var specificList = new CategoryModel())
            {
                return specificList.Products.Where(i => i.ProductID == byID).ToList();
            }
        }

        public Product FindByID(string id)
        {
            using (var idProduct = new CategoryModel())
            {
                return idProduct.Products.SingleOrDefault(p => p.ProductID == id);
            }
        }

        public Product FindByName(string name)
        {
            using (var nameProduct = new CategoryModel())
            {
                return nameProduct.Products.SingleOrDefault(n => n.ProductName.ToLower() == name.ToLower());
            }
        }

        public void InsertUpdate(Product p)
        {
            using (var forInsert = new CategoryModel())
            {
                forInsert.Products.AddOrUpdate(p);
                forInsert.SaveChanges();
            }
        }


        public void DeleteUpdate(Product p)
        {
            using (var forDelete = new CategoryModel())
            {
                forDelete.Products.Attach(p);
                forDelete.Products.Remove(p);
                forDelete.SaveChanges();
            }
        }
    }

}

