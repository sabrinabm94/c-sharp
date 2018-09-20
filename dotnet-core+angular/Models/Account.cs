using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Model
{
    public class Account
    {
        public int id { get => id; set => id = value; }
        public string type { get => type; set => type = value; }
        public double balance { get => balance; set => balance = value; }
        public DateTime registration { get => registration; set => registration = value; }
        public int userId { get => userId; set => userId = value; }
    }
}
