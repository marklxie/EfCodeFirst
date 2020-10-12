﻿using System;
using System.Linq;

namespace EfCodeFirst {
	class Program {
		static void Main(string[] args) {
			var _context = new AppDbContext();
			var cust = new Customer() {
				Name = "Max",
				Code = "Max",
				Active = true,
				Sales = 1000,
				Created = DateTime.Now
			};
			//_context.Customers.Add(cust);
			//_context.SaveChanges();
			var custs = _context.Customers.ToList();
			foreach(var c in custs) {
				Console.WriteLine($"{c.Id}|{c.Name}|{c.Code}|{c.Active}|{c.Sales}|{c.Created}");

			}

			var ord = new Order() {
				Description = "First Order",
				Total = 1000,
				Created = DateTime.Now,
				CustomerId = 1
			};

			//_context.Orders.Add(ord);
			//_context.SaveChanges();
			var ords = _context.Orders.Find(1);
			Console.WriteLine($"{ords.Id}|{ords.Description}|{ords.Created}|{ords.Created}|{ords.CustomerId}");

			var ordline = new Orderline() {
				Product = "Echo", Price = 100, Quantity = 3, OrderId = 1
			};

			_context.Orderlines.Add(ordline);
			_context.SaveChanges();
			var ordAll = from o in _context.Orders
						 join c in _context.Customers
						 on o.CustomerId equals c.Id
						 join l in _context.Orderlines
						 on o.Id equals l.OrderId
						 select new {
							 OrderId = o.Id,
							 Desc = o.Description,
							 Customer = c.Name,
							 l.Product,
							 l.Price,
							 l.Quantity,
							 LineTotal = l.Price * l.Quantity
						 };


			ordAll.ToList();

		}
	}
}
