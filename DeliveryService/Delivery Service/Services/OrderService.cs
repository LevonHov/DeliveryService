using Delivery_Service.Models;
using Delivery_Service.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Service.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly LogService _logService;

        public OrderService(OrderRepository orderRepository, LogService logService)
        {
            _orderRepository = orderRepository;
            _logService = logService;
        }

        public List<Order> ReadOrders(string filePath)
        {
            try
            {
                return _orderRepository.GetOrdersFromFile(filePath);
            }
            catch (Exception ex)
            {
                _logService.LogError($"Error reading orders: {ex.Message}");
                return new List<Order>();
            }
        }

        public List<Order> FilterOrdersByDistrictAndTime(List<Order> orders, string district, DateTime firstDeliveryTime)
        {
            List<Order> filteredOrders = new List<Order>();
            DateTime endTime = firstDeliveryTime.AddMinutes(30);

            foreach (var order in orders)
            {
                if (order.District.Equals(district, StringComparison.OrdinalIgnoreCase) &&
                    order.DeliveryTime <= firstDeliveryTime && order.DeliveryTime <= endTime)
                {
                    filteredOrders.Add(order);
                }
            }
            return filteredOrders;
        }

        public void SaveFilteredOrders(List<Order> filteredOrders, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (Order order in filteredOrders)
                    {
                        writer.WriteLine($"{order.OrderId},{order.Weight},{order.District},{order.DeliveryTime}");
                    }
                }
                _logService.LogInfo($"Successfully saved {filteredOrders.Count} filtered orders to {filePath}");
            }
            catch (Exception ex)
            {
                _logService.LogError($"Error saving orders: {ex.Message}");
            }
        }
    }
}
