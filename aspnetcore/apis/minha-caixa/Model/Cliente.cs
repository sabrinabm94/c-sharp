using System;

namespace MinhaCaixa.Model
{
    public class Cliente
    {
        public int ClienteCodigo { get; set; } //CONSTRAINT PK_CLIENTES PRIMARY KEY IDENTITY(1,1)
        public int ClienteCPF { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteSobrenome { get; set; }
        public string ClienteSexo { get; set; }
        public DateTime ClienteNascimento { get; set; }
        public string ClienteEstadoCivil { get; set; }
        public string ClienteRua { get; set; }
        public int ClienteNumero { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteCEP { get; set; }
        public string ClienteCidade { get; set; }
        public string ClienteEstado { get; set; }
        public string ClientePais { get; set; }
        public double ClienteRendaAnual { get; set; }
        public string ClienteTelefone { get; set; }
        public string ClienteEmail { get; set; }
    }
}