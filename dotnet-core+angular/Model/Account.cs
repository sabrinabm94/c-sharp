using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Account
    {
        public int id;
        public double balance;
        public int userId;

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }

        public void setBalance(double balance)
        {
            this.balance = balance;
        }
        public double getBalance()
        {
            return this.balance;
        }

        public void setUserId(int userId)
        {
            this.userId = userId;
        }
        public int getUserId()
        {
            return this.userId;
        }
    }
}
