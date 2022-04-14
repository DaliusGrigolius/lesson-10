using lesson_10.Business;
using System;
using System.Collections.Generic;

namespace lesson_10.DataAccess
{
    public class OrderRepository
    {
        private List<Order> OrdersList { get; }

        public OrderRepository()
        {
            OrdersList = new List<Order>();

            List<Product> products = new List<Product>();
            products.Add(new Product("Produktas 1", "Aprasymas1", 1.99m));
            products.Add(new Product("Produktas 1", "Aprasymas1", 1.99m));
            products.Add(new Product("Produktas 1", "Aprasymas1", 1.99m));
            products.Add(new Product("Produktas 2", "Aprasymas2", 2.99m));
            products.Add(new Product("Produktas 3", "Aprasymas3", 3.99m));

            OrdersList.Add(new Order(DateTime.Now, "abc1", products));
            OrdersList.Add(new Order(DateTime.Now, "abc2", products));
            OrdersList.Add(new Order(DateTime.Now, "abc3", products));
        }

        public List<Order> Retrieve()
        {
            return OrdersList;
        }

        public Order Retrieve(int uniqueOrderId)
        {
            return OrdersList[uniqueOrderId];
        }
    }
}
