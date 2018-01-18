using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Checkout.Contracts;

namespace Checkout.App
{
    public class Checkout : ICheckout
    {
        private List<ShoppingItem> ShoppingList = new List<ShoppingItem>();
        private List<Product> Prices = new List<Product>();

        public Checkout()
        {
            // Add item A
            Prices.Add(CreateNewProduct("A", 50, true, 3, 130));
            // Add item B
            Prices.Add(CreateNewProduct("B", 30, true, 2, 45));
            // Add item C
            Prices.Add(CreateNewProduct("C", 20));
            // Add item D
            Prices.Add(CreateNewProduct("D", 15));
        }

        private Product CreateNewProduct(string sku, int unitPrice, bool hasSo = false, int? soUnits= null, int? soPrice= null)
        {
            Offer specialOffer = null;
            if (hasSo)
            {
                // check if soUnits has value
                if(!soUnits.HasValue)
                    throw new ArgumentException("Special offer units must have a value");

                // check if soPrice has value
                if (!soPrice.HasValue)
                    throw new ArgumentException("Special offer price must have a value");

                specialOffer = new Offer
                {
                    Units = soUnits.Value,
                    Price = soPrice.Value
                };
            }
                

            var product = new Product
            {
                Sku = sku,
                UnitPrice = unitPrice,
                SpecialOffer = specialOffer
            };
            return product;
        }

        public int GetTotal()
        {
            var total = 0;
            foreach (var shoppingItem in ShoppingList)
            {
                var itemPrice = (from price in Prices
                    where price.Sku == shoppingItem.Sku
                    select price).FirstOrDefault();

                if (itemPrice != null)
                {
                    if (itemPrice.SpecialOffer != null)
                    {
                        total += ((int) (shoppingItem.Amount / itemPrice.SpecialOffer.Units)) * itemPrice.SpecialOffer.Price
                                 + (shoppingItem.Amount % itemPrice.SpecialOffer.Units) * itemPrice.UnitPrice;
                    }
                    else
                    {
                        total += shoppingItem.Amount * itemPrice.UnitPrice;
                    }
                }
            }
            return total;
        }

        public void Scan(string sku)
        {
            var item = (from shoppingItem in ShoppingList
                where shoppingItem.Sku == sku
                select shoppingItem).FirstOrDefault();

            if (item == null)
            {
                ShoppingList.Add(new ShoppingItem {Amount = 1, Sku = sku});
            }
            else
            {
                item.Amount++;
            }
        }
    }

    
}
