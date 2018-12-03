using System;

namespace MinhaCaixa.Models
{
    public class Movimento
    {
        
        public string ContaNumero { get; set; }
        public DateTime MovimentoData { get; set; }
        public double MovimentoValor { get; set; }
        public int MovimentoTipo { get; set; }
        public int MovimentoCodigo { get; set; } //identity
    }
}