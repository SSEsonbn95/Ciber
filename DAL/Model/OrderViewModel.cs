using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OrderViewModel
    {
        public int Stt { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Amount { get; set; }
        
    }
}
