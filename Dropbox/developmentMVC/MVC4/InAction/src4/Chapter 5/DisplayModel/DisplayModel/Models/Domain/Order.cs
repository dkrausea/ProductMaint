using System;
using System.Collections.Generic;

namespace DisplayModel.Models.Domain
{
	public class Order
	{
		public DateTime Date { get; set; }
		public IEnumerable<Product> Product { get; set; }
		public decimal TotalAmount { get; set; }
	}
}