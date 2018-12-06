namespace MinhaCaixa.Model
{
    public class Grupo
    {
        public int GrupoCodigo { get; set; } //INT IDENTITY(1,1) CONSTRAINT PK_Grupo PRIMARY KEY
        public string GrupoNome { get; set; }
        public string GrupoRazaoSocial { get; set; }
        public double GrupoCNPJ { get; set; }
    }
}