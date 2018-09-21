using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Model
{
    public class User
    {
        public int id { get => id; set => id = value; }
        public string name { get => name; set => name = value; }
        public string username { get => username; set => username = value; }
        public string password { get => password; set => password = value; }
        public int cpf { get => cpf; set => cpf = value; }
        //public DateTime registration { get => registration; set => registration = value; }
        public int accountId { get => accountId; set => accountId = value; }
    }
}