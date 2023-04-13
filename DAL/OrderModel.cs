using DAL.EntityFramework;
using DAL.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderModel
    {

        public List<OrderViewModel> ListAllOrders(string textSearch)
        {
            using (var context = new MyDbContext())
            {
                object[] parameters =
               {
                    new SqlParameter("@textSearch",!string.IsNullOrEmpty(textSearch)?textSearch:"")
                };
                var list = context.Database.SqlQuery<OrderViewModel>("Exec GetOrdersByPage @textSearch", parameters).ToList();
                return list;
            }
               
            
        }
        public int CreateNewOrder(CreateNewOrderModel entity)
        {
            using (var context = new MyDbContext())
            {
                object[] parameters =
                    {
                    new SqlParameter("@OrderName",entity.orderName),
                    new SqlParameter("@ProductId",entity.productId),
                    new SqlParameter("@CustomerId",entity.customerId),
                    new SqlParameter("@OrderDate",entity.orderDate),
                    new SqlParameter("@Amount",entity.amount)
                };
                var resurt = context.Database.ExecuteSqlCommand("Exec CreateNewOrder @OrderName,@ProductId,@CustomerId,@OrderDate,@Amount", parameters);
                return resurt;
            }
        }
    }
}
