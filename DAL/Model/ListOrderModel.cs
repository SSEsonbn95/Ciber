using DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
	public class ListOrderModel
	{
        public string textSearch { get; set; }
        public decimal CountAll { get; set; }
        public int? page_active { get; set; }
        public List<OrderViewModel> ListOrders { get; set; }
        public List<ProductViewModel> ListProducts { get; set; }
        public List<CustomerViewModel> ListCustomers { get; set; }
    }
}
