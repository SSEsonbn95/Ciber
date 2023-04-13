using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class CreateNewOrderModel
    {
        public string orderName { get; set; }
        public string productId { get; set; }
        public string customerId { get; set; }
        public DateTime? orderDate { get; set; }
        public decimal? amount { get; set; }
        
    }
}
