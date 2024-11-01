using Delivery_Service.Models;
using Delivery_Service.Repositories;
using Delivery_Service.Services;
using System;
using System.Collections.Generic;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path to the orders file:");
            string inputFilePath = Console.ReadLine();

            Console.Write("Enter the path to the results file:");
            string outputFilePath = Console.ReadLine();

            Console.Write("Enter the district for filtering:");
            string deliveryDistrict = Console.ReadLine();

            Console.Write("Enter the time for the first delivery (format: yyyy-MM-dd HH:mm:ss):");
            string timeInput;
            DateTime firstDeliveryTime;

            do
            {
                timeInput = Console.ReadLine();

                if (!DateTime.TryParse(timeInput, out firstDeliveryTime))
                {
                    Console.Write("Invalid time format. Please use format: yyyy-MM-dd HH:mm:ss");
                }
            }
            while (!DateTime.TryParse(timeInput, out firstDeliveryTime));




            Console.Write("Enter the log file name (e.g., delivery.log):");
            string logFilePath = Console.ReadLine();

            LogService logService = new LogService(logFilePath);
            ;

            OrderRepository orderRepository = new OrderRepository();
            OrderService orderService = new OrderService(orderRepository, logService);

            List<Order> orders = orderService.ReadOrders(inputFilePath);

            List<Order> filteredOrders = orderService.FilterOrdersByDistrictAndTime(orders, deliveryDistrict, firstDeliveryTime);

            orderService.SaveFilteredOrders(filteredOrders, outputFilePath);
            Console.Read();
        }
    }
}
