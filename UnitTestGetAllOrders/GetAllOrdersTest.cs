using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using DAL;
using DAL.EntityFramework;
using DAL.Model;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class OrderModelTests
    {
        private MyDbContext _context;
        private OrderModel _orderModel;

        [SetUp]
        public void Setup()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            _context = new MyDbContext();
            _orderModel = new OrderModel {};
        }

        [Test]
        public void ListAllOrders_Should_Return_Correct_Result()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { OrderId = 1, ProductId = 1,CustomerId = 1, OrderDate = new DateTime(2022, 1, 1),Amount =100 },
                new Order { OrderId = 2, ProductId = 2,CustomerId = 2, OrderDate = new DateTime(2022, 1, 1),Amount =200 }
            };
            _context.Orders.AddRange(orders);
            var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "Son",Address ="HN" },
                new Customer { CustomerId = 2, Name = "Phuong",Address ="HN" }
            };
            _context.Orders.AddRange(orders);
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Fridge",Price =100 },
                new Product { ProductId = 2, Name = "TV",Price =200 }
            };
            _context.Orders.AddRange(orders);
            _context.SaveChanges();

            // Act
            var result = _orderModel.ListAllOrders("");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Son", result[0].CustomerName);
            Assert.AreEqual("Phuong", result[1].CustomerName);
            Assert.AreEqual("Fridge", result[0].ProductName);
            Assert.AreEqual("TV", result[1].ProductName);
            Assert.AreEqual(100, result[0].Amount);
            Assert.AreEqual(200, result[1].Amount);
        }
    }
}