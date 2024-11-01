public class Municipio
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Escola> Escolas { get; set; }
}
