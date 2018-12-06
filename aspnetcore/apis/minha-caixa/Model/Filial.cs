namespace MinhaCaixa.Model
{
    public class Filial
    {
        public int GrupoCodigo { get; set; }
        public int FilialCodigo { get; set; } //IDENTITY(1,1) CONSTRAINT PK_Filial PRIMARY KEY
        public string FilialNome { get; set; }  
        public string FilialRazaoSocial { get; set; }
        public string FilialCNPJ { get; set; }
    }
}