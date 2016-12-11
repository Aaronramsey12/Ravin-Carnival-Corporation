using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CruiseReservation.Models;

namespace CruiseReservation.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private TourContext db = new TourContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart (int id)
        {
            //Retriieve the product from the database
            ShoppingCartId = GetCartId();

            var cartItem = db.ShoppingCartItems.SingleOrDefault(c => c.CartId == ShoppingCartId && c.TourID == id);
            if (cartItem == null)
            {
                //ceate  a new cart item if no cart item exists.
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    TourID = id,
                    CartId = ShoppingCartId,
                    Tour = db.Tours.SingleOrDefault(p => p.TourID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                //  if the item does exist in the cart,
                //then add on the to the quantity.
                cartItem.Quantity++;
            }
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
                {
                db.Dispose();
                db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    //Genrate a new random GUID using Sytem.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }
        public List<CartItem>GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return db.ShoppingCartItems.Where(c => c.CartId == ShoppingCartId).ToList();
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            //Multiply tour price by quantity of that product to get
            //the current price for each of those tour in the cart.
            //sum all product price totals to get the cart total.
            decimal? total = decimal.Zero;
            total = (decimal?)(from CartItem in db.ShoppingCartItems
                               where CartItem.CartId == ShoppingCartId
                               select (int?)CartItem.Quantity * CartItem.Tour.UnitPrice).Sum();
            return total ?? decimal.Zero; 
        }

        public ShoppingCartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase (String cartId, ShoppingCartUpdates[]CartItemUpdates)
        {
            using (var db = new CruiseReservation.Models.TourContext())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CartItem> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        //Iterate through all rows within shopping cart list
                        for(int i = 0; i<CartItemCount; i++)
                        {
                            if (cartItem.Tour.TourID == CartItemUpdates[i].TourId)
                            {
                                if(CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.TourID);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.TourID, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Error: unableto update cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeTourID)
        {
            using (var db = new CruiseReservation.Models.TourContext())
            {
                try
                {
                    var myItem = (from c in db.ShoppingCartItems where c.CartId == removeCartID && c.Tour.TourID == removeTourID select c).FirstOrDefault();
                    if(myItem!=null)
                    {
                        //Remove Item.
                        db.ShoppingCartItems.Remove(myItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Error: unable to remove cart tem -" + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem (string updateCartID,int updateTourID, int quantity)
        {
            using (var db = new CruiseReservation.Models.TourContext())
            {
                try
                {
                    var myItem = (from c in db.ShoppingCartItems where c.CartId == updateCartID && c.Tour.TourID == updateTourID select c).FirstOrDefault();
                    if(myItem !=null)
                    {
                        myItem.Quantity = quantity;
                        db.SaveChanges();
                    }
                }
                catch(Exception exp)
                {
                    throw new Exception("Error: Unable to Update cart item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = db.ShoppingCartItems.Where(c => c.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                db.ShoppingCartItems.Remove(cartItem);
            }
            //save changes.
            db.SaveChanges();
        }

        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            //Get the countof eachitem in the cart and sum them up
            int? count = (from CartItem in db.ShoppingCartItems where CartItem.CartId == ShoppingCartId select (int?)CartItem.Quantity).Sum();
            //Return 0 if all entries are null
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int TourId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public void MigrateCart (string cartId, string userName)
        {
            var shoppingCart = db.ShoppingCartItems.Where(c => c.CartId == cartId);
            foreach (CartItem item in shoppingCart)
            {
                item.CartId = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            db.SaveChanges();
        }
    }
}