using MyWebApp.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IGrupoRepository
    {
        List<Grupo> list();
        Grupo listById(int id);
        Grupo save(Grupo grupo);
        Grupo deleteById(int id);
        Grupo delete(Grupo grupo);
        Grupo update(Grupo grupo);
    }
}