using System;

namespace MinhaCaixa.Models
{
    public class Conta
    {
        public int AgenciaCodigo { get; set; }
        public string ContaNumero { get; set; } //CONSTRAINT PK_Conta PRIMARY KEY,
        public int ClienteCodigo { get; set; }
        public DateTime ContaAbertura { get; set; }
        public int ContaTipo { get; set; }
    }
}