using Domain.Entities;
using System;

namespace WebApp.Areas.Admin.Models.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int QuantityProduct { get; set; }
        public double BuyPrice { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Orders { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}