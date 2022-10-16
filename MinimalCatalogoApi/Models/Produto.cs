using System.Text.Json.Serialization;

namespace MinimalCatalogoApi.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? Imagem { get; set; }
        public DateTime DataCompra { get; set; }
        public int Estoque { get; set; }

        //Relacionamento um para muitos
        public int CategoriaId { get; set; }

        [JsonIgnore] // esse método ignora essa relação de produtos nao sendo exibida no json do post categorias
        public Categoria? Categoria { get; set; }
    }
}
