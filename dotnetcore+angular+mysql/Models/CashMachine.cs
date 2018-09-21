using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Model
{
    public class CashMachine
    {
        public int id { get => id; set => id = value; }
        public double balance { get => balance; set => balance = value; }
    }
}
