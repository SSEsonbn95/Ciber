using DAL.EntityFramework;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerModel
    {
        private MyDbContext Context = null;
        public CustomerModel()
            {
            Context = new MyDbContext();
            }
        public List<CustomerViewModel> ListAllCustomers()
        {
            try
            {
                var list = Context.Database.SqlQuery<CustomerViewModel>("Exec GetAllCustomers").ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }      
    }
}
