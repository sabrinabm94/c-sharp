using System;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IAccountRepository
    {
        List<Agencia> list();
        Agencia listById(int id);
        Agencia save(Agencia agencia);
        Agencia deleteById(int id);
        Agencia delete(Agencia agencia);
        Agencia update(Agencia agencia);
    }
}