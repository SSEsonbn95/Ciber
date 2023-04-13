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
    public class ProductModel
    {
        private MyDbContext Context = null;
        public ProductModel()
            {
            Context = new MyDbContext();
            }
        public List<ProductViewModel> ListAllProducts()
        {
            var list = Context.Database.SqlQuery<ProductViewModel>("Exec GetAllProducts").ToList();
            return list;
        }      
    }
}
