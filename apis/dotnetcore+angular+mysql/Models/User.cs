using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Model
{
    public class User
    {
        public int id { get => id; set => id = value; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int cpf { get; set; }
        //public DateTime registration { get => registration; set => registration = value; }
        public int accountId { get; set; }
    }
}