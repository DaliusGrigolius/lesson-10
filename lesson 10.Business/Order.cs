using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson_10.Business
{
    public class Order
    {
        public DateTime OrderDate { get; }
        public string ShippingAdress { get; }
        public List<OrderProduct> OrderProducts { get; }

        public Order(DateTime orderDate, string shippingAdress, List<Product> products)
        {
            OrderDate = orderDate;
            ShippingAdress = shippingAdress;

            OrderProducts = new List<OrderProduct>();
            foreach (var product in products)
            {
                bool isProductAdded = IsProductAlreadyAdded(product);
                if (!isProductAdded)
                {
                    int quantity = CountProducts(products, product);
                    OrderProducts.Add(new OrderProduct(product, quantity));
                }
            }
        }

        private int CountProducts(List<Product> productsList, Product product)
        {
            return productsList.Count(i => i.Name == product.Name);
        }

        private bool IsProductAlreadyAdded(Product product)
        {
            return OrderProducts.Any(i => i.Product.Name == product.Name);
        }
        
        public decimal CountPrice()
        {
            decimal price = 0;
            for (int i = 0; i < OrderProducts.Count; i++)
            {
                price += OrderProducts[i].Product.CurrentPrice * OrderProducts[i].Quantity;
            }
            return price;
        }

        public void Validate()
        {

        }
    }
}
