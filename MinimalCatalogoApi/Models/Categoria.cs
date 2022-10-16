using System.Text.Json.Serialization;

namespace MinimalCatalogoApi.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        //Relacionamento aonde uma categoria tem muitos produtos
        [JsonIgnore] // esse método ignora essa relação de produtos nao sendo exibida no json do post categorias
        public ICollection<Produto>? Produtos { get; set; }
    }
}
