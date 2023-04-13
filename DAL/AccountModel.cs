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
    public class AccountModel
    {
        private MyDbContext Context = null;
        public AccountModel()
            {
                Context = new MyDbContext();
            }
        public bool Login(string userName,string password)
        {
            try
            {
                object[] parameters =
                    {
                    new SqlParameter("@UserName",userName),
                    new SqlParameter("@Password",password),
            };
                var resurt = Context.Database.SqlQuery<bool>("Exec User_Login @UserName,@Password", parameters).FirstOrDefault();
                return resurt;
            }
            catch
            {
                return false;
            }
        }      
    }
}
