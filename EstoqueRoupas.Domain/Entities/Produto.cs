namespace EstoqueRoupas.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string NomeCompleto => $"{Nome} + {Descricao}";
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}
