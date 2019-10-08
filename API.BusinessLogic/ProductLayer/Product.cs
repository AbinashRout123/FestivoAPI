using API.DataAccessLayer;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.BusinessLogic.ProductLayer
{
    public class Product
    {
        FestivoDBContext context = new FestivoDBContext();
        Register register = new Register();

        public void AddProduct(Products product)
        {
            context.products.Add(product);
            context.SaveChanges();
        }

        public IEnumerable<Categories> getCategory()
        {
            return context.categories;
        }

        public IEnumerable<Products> getProducts()
        {
            return context.products;
        }

        public IEnumerable<Products> GetProductsByCategoryId(int categoryId)
        {
            return context.products.Where(p => p.CategoryId == categoryId);
        }

        public bool UpdateData(int id, Products model)
        {
            
            var query = context.products.Where(z => z.ProductId == id).FirstOrDefault();
     
            query.ProductName = model.ProductName;
            query.ProductImage = model.ProductImage;
            query.ProductDescription = model.ProductDescription;
            query.ProductPrice = model.ProductPrice;
            query.Quantity = model.Quantity;
            context.SaveChanges();
            return true;

        }

        public bool DeleteData(int id)
        {

            var query = context.products.Where(z => z.ProductId == id).FirstOrDefault();
            context.Entry(query).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return true;

        }

    }
}
