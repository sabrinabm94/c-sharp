using MyWebApp.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IMovimentoRepository
    {
        List<Movimento> list();
        Movimento listById(int id);
        Movimento save(Movimento movimento);
        Movimento deleteById(int id);
        Movimento delete(Movimento movimento);
        Movimento update(Movimento movimento);
    }
}