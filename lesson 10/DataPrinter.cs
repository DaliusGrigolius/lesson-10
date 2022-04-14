using lesson_10.Business;
using lesson_10.DataAccess;
using System;
using System.Collections.Generic;

namespace lesson_10
{
    public class DataPrinter
    {
        public void PrintProductList()
        {
            Console.WriteLine("Programa pasileidžia...");
            Console.WriteLine();
            ProductRepository prodRep = new ProductRepository();
            List<Product> productsList = prodRep.Retrieve();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Turimų prekių sąrašas:");
            Console.ResetColor();
            Console.WriteLine();
            for (int i = 0; i < productsList.Count; i++)
            {
                Console.Write($"- {productsList[i].Name}, {productsList[i].Description}, {productsList[i].CurrentPrice}\r\n");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();
        }

        public void PrintOrdersData()
        {
            OrderRepository orderRepository = new OrderRepository();
            List<Order> orders = orderRepository.Retrieve();
            Console.WriteLine($"Viso uzsakymu rinkiniu: {orders.Count}");
            Console.WriteLine();
            decimal totalPrice = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"  Uzsakymo nr.{i + 1} duomenys:");
                Console.WriteLine($"      Uzsakymo data: {orders[i].OrderDate}, uzsakymo adresas: {orders[i].ShippingAddress}.");
                for (int j = 0; j < orders[i].OrderProducts.Count; j++)
                {
                    Product product = orders[i].OrderProducts[j].Product;
                    Console.WriteLine($"      Produktas: {product.Name}; " +
                        $"Produkto aprašymas: {product.Description}; " +
                        $"Produkto kaina/vnt.: {product.CurrentPrice}; " +
                        $"Užsakytas kiekis: {orders[i].OrderProducts[j].Quantity}.");
                }

                decimal priceToPay = orders[i].CountPrice();
                Console.WriteLine($"      Moketi isviso: {priceToPay}");
                Console.WriteLine();
                totalPrice += priceToPay;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Viso sumokėta: ");
            Console.ResetColor();
            Console.WriteLine(totalPrice);
            Console.WriteLine();
            Console.WriteLine("Programa pasibaigia...");
            Console.ReadLine();
        }
    }
}
