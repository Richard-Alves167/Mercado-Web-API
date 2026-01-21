using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ProdutoReadDTO {
        public ProdutoReadDTO(int id, string nome, decimal preco, int estoque, string imagem) {
            Id = id;
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
            Imagem = imagem;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; } = "https://s3.wasabisys.com/horseplace.smserver.com.br/img/products/default.jpg";
        public int Estoque { get; set; }
    }
}
