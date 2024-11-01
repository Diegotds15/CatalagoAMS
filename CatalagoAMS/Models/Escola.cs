using CatalagoAMS.Models;

public class Escola
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Diretor { get; set; }
    public string Auxiliares { get; set; }
    public string Ideb { get; set; }
    public string AnosFinais { get; set; }
    public string EnsinoMedio { get; set; }
    public string CodigoINEP { get; set; }
    public int MunicipioId { get; set; }
    public Municipio Municipio { get; set; }
}