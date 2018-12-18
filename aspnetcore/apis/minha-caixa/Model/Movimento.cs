using System;

namespace MinhaCaixa.Model
{
    public class Movimento
    {
        public int MovimentoCodigo { get; set; } //identity
        public string ContaNumero { get; set; }
        public DateTime MovimentoData { get; set; }
        public double MovimentoValor { get; set; }
        public int MovimentoTipo { get; set; }
    }
}