using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.Interfaces;
using Проект.BLL.VMs.Product;
using Проект.DAL;
using Проект.Models;

namespace Проект.BLL.Services
{
    public class ProductService : IProductService
    {
        readonly AppDbContext db;


        public ProductService()
        {
            db = new AppDbContext();
        }
        public ProductService(AppDbContext _db)
        {
            db = _db;
        }






        public bool CreateProduct(CreateUpdateProductVM newProduct)
        {
            try
            {
                db.Products.Add(new Product() { price = newProduct.price, description = newProduct.description, name = newProduct.name, category = newProduct.category, number = newProduct.number });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteProduct(Guid productId)
        {
            throw new NotImplementedException();
        }


        public List<OpenProductListVM> GetAllProducts()
        {
            List<OpenProductListVM> result = new List<OpenProductListVM>();

            var dbProducts = db.Products.ToList();

            foreach (var dbProduct in dbProducts)
            {
                result.Add(new OpenProductListVM() { price = dbProduct.price, Id = dbProduct.id, name = dbProduct.name, number = dbProduct.number, category = dbProduct.category});
            }
            return result;
        } 


        public OpenProductVM GetProduct(Guid productId)
        {
            OpenProductVM result = new OpenProductVM();

            var dbProducts = db.Products.ToList();

            foreach (var dbProduct in dbProducts)
            {
                if (dbProduct.id == productId)
                {
                    result.category = dbProduct.category;
                    result.description = dbProduct.description;
                    result.Id = dbProduct.id;
                    result.name = dbProduct.name;
                    result.number = dbProduct.number;
                    result.price = dbProduct.price;
                    
                }
            }
            return result;
        }


        public bool UpdateProduct(Guid productId, OpenProductVM editedProduct)
        {
            try
            {
                var dbProducts = db.Products.ToList();

                foreach (var product in dbProducts)
                {
                    if (product.id == productId)
                    {

                        product.category = editedProduct.category;
                        product.description = editedProduct.description;
                        product.id = editedProduct.Id;
                        product.name = editedProduct.name;
                        product.number = editedProduct.number;
                        product.price = editedProduct.price;
                    }
                }



                foreach (var product in dbProducts)
                {
                    db.Entry(product).State = EntityState.Modified;
                }

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
