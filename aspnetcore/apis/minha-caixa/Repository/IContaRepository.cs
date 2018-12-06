using MinhaCaixa.Model;
using System.Collections.Generic;

namespace MyWebApp.Repository
{
    public interface IContaRepository
    {
        List<Conta> list();
        Conta listById(int id);
        Conta save(Conta conta);
        Conta deleteById(int id);
        Conta delete(Conta conta);
        Conta update(Conta conta);
    }
}