using API.DataAccessLayer;
using API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.BusinessLogic.ProductLayer
{
    public class ShoppingCart
    {
        FestivoDBContext db = new FestivoDBContext();
        Register r = new Register();
        CartItem cart = new CartItem();

        public bool AddCart(CartItem cart)
        {
            var inStock = db.products.Where(p => p.ProductId == cart.ProductId).FirstOrDefault();
            int quantity = inStock.Quantity;

            if (quantity > cart.Quantity)
            {
                var verify = db.carts.Where(p => p.ProductId == cart.ProductId && p.UserId == cart.UserId).FirstOrDefault();
                if (verify == null)
                {
                    db.carts.Add(cart);
                    db.SaveChanges();
                    var cartItem = db.carts.Where(x => x.CartId == cart.CartId).FirstOrDefault();
                    var product = db.products.Where(p => p.ProductId == cart.ProductId).FirstOrDefault();
                    string Name = product.ProductName;
                    //string Image = product.ProductImage;
                    int MRP = product.ProductPrice;
                    cartItem.ProductName = Name;
                    //cartItem.ProductImage = Image;
                    cartItem.ProductPrice = MRP;
                    cartItem.ProductTotal = (cartItem.Quantity * MRP);
                    db.SaveChanges();
                    return true;

                }
                else
                {
                    verify.Quantity = verify.Quantity + cart.Quantity;
                    verify.ProductTotal = verify.ProductTotal + (verify.ProductPrice * cart.Quantity);
                    db.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public bool RemoveCart(CartItem item)
        {
            var verify = db.carts.Where(p => p.ProductId == item.ProductId && p.UserId == item.UserId).FirstOrDefault();
            if (verify.Quantity == 1)
            {
                db.Entry(verify).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return true;

            }
            else if (verify.Quantity > 1)
            {
                verify.Quantity = verify.Quantity - item.Quantity;
                verify.ProductTotal = verify.ProductTotal - (verify.ProductPrice * item.Quantity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearCart(CartItem clear)
        {
            var verify = db.carts.Where(p => p.ProductId == clear.ProductId && p.UserId == clear.UserId).FirstOrDefault();
            db.Entry(verify).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public bool DeleteCart(CartItem delete)
        {


            var verify = db.carts.Where(p => p.UserId == delete.UserId);
            foreach (var c in verify)
            {
                var query = db.orders.Where(z => z.ProductId == c.ProductId).FirstOrDefault();
                //query.Quantity -= c.Quantity;
                //db.SaveChanges();
                //OrderHistory order = new OrderHistory
                //{
                //    ProductId = c.ProductId,
                //    ProductName = c.ProductName,
                //    ProductPrice = c.ProductPrice,
                //    Quantity = c.Quantity,
                //    ProductTotal = c.ProductTotal,
                //    UserId = c.UserId

                //};
                //db.orders.Add(order);
                db.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }

            db.SaveChanges();
            return true;
        }


        public int CartTotal(CartItem cart)
        {
            int cartTotal = 0;
            var total = from c in db.carts where c.UserId == cart.UserId select c;
            foreach (var i in total)
            {
                cartTotal = cartTotal + i.ProductTotal;
            }
            return cartTotal;
        }
        //public bool ProductValid(int id)
        //{
        //    var query = db.products.Where(p => p.ProductId == id).FirstOrDefault();
        //    if (query == null)
        //        return false;
        //    else
        //        return true;
        //}

        //public bool DataValid(int id)
        //{
        //    var query = db.users.Where(u => u.UserId == id).FirstOrDefault();
        //    if (query == null)
        //        return false;
        //    else
        //        return true;
        //}


        public IEnumerable<CartItem> GetCartValue(CartItem model)
        {
            var query = from c in db.carts where c.UserId == model.UserId select c;
            return query;
        }
    }
}

