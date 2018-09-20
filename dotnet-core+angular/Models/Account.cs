using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class Account : DbContext
    {
        public int id { get => id; set => id = value; }
        public int type { get => type; set => type = value; }
        public double balance { get => balance; set => balance = value; }
        public int userId { get => userId; set => userId = value; }
    }
}
