namespace MinhaCaixa.Model
{
    public class Agencia
    {
        public int GrupoCodigo { get; set; }
        public int FilialCodigo { get; set; } 
        public int AgenciaCodigo { get; set; } //IDENTITY CONSTRAINT PK_Agencias PRIMARY KEY
        public string AgenciaNome { get; set; }
        public string AgenciaRua { get; set; }
        public int AgenciaNumero { get; set; }
        public string AgenciaBairro { get; set; }
        public string AgenciaCEP { get; set; }
        public string AgenciaCidade { get; set; }
        public string AgenciaEstado { get; set; }
        public string AgenciaPais { get; set; }
    }
}