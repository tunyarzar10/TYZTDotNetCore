﻿using Microsoft.EntityFrameworkCore;
using TYZTDotNetCore.PizzaApi.Models;
using ZackDotNet.PizzaApi;

namespace TYZTDotNetCore.PizzaApi.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<PizzaExtraModel> PizzaExtras { get; set; }
        public DbSet<PizzaOrderModel> PizzaOrders { get; set; }
        public DbSet<PizzaOrderDetailModel> PizzaOrderDetails { get; set; }

    }

    public class OrderRequest
    {
        public int PizzaId { get; set; }
        public int[] Extras { get; set; }
    }

    public class OrderResponse
    {
        public string Message { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class PizzaOrderInvoiceHeadModel
    {
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public int PizzaId { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }
    }

    public class PizzaOrderInvoiceDetailModel
    {
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
        public string PizzaExtraName { get; set; }
        public decimal Price { get; set; }
    }

    public class PizzaOrderInvoiceResponse
    {
        public PizzaOrderInvoiceHeadModel Order { get; set; }
        public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
    }
}