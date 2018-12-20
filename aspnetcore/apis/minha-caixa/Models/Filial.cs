namespace MyWebApp.Model
{
    public class Filial
    {
        public int FilialCodigo { get; set; } //IDENTITY(1,1) CONSTRAINT PK_Filial PRIMARY KEY
        public int GrupoCodigo { get; set; }
        public string FilialNome { get; set; }  
        public string FilialRazaoSocial { get; set; }
        public string FilialCNPJ { get; set; }
    }
}