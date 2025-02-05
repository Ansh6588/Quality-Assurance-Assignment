using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; set; }

        public Product(int prodId, string prodName, decimal itemPrice, int stockAmount)
        {
            if (prodId < 5 || prodId > 50000)
                throw new ArgumentException("Product ID must be between 5 and 50000.");

            if (itemPrice < 5 || itemPrice > 5000)
                throw new ArgumentException("Item price must be between $5 and $5000.");

            if (stockAmount < 5 || stockAmount > 500000)
                throw new ArgumentException("Stock amount must be between 5 and 500000.");

            ProdId = prodId;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount > 0)
            {
                StockAmount += amount;
            }

        }
        public void DecreaseStock(int amount)
        {
            int minStock = 5;
            if (StockAmount - amount < minStock)
            {
                StockAmount = minStock; 
            }
            else
            {
                StockAmount -= amount;
            }

        }


    }
}
