using Delivery_Service.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Delivery_Service.Repositories
{
    public class OrderRepository
    {
        public List<Order> GetOrdersFromFile(string filePath)
        {
            var orders = new List<Order>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.", filePath);
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                var data = line.Split(',');

                if (data.Length == 4)
                {
                    if (int.TryParse(data[0].Trim(), out int orderId) &&
                        double.TryParse(data[1].Trim(), out double weight) &&
                        DateTime.TryParse(data[3].Trim(), out DateTime deliveryTime))
                    {
                        string district = data[2].Trim();

                        orders.Add(new Order
                        {
                            OrderId = orderId,
                            Weight = weight,
                            District = district,
                            DeliveryTime = deliveryTime
                        });
                    }
                    else
                    {
                        Console.WriteLine($"Failed to parse line: {line}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid data structure on line: {line}");
                }
            }

            return orders;
        }
        public void SaveOrdersToFile(List<Order> orders, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var order in orders)
                {
                    writer.WriteLine($"{order.OrderId},{order.Weight},{order.District},{order.DeliveryTime}");
                }
            }
        }
    }

}
