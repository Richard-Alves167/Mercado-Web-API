using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Service {
    public class ProdutoService : IProdutoService {
        private IProdutoRepository _repos;
        public ProdutoService(IProdutoRepository produtoRepository) {
            _repos = produtoRepository;
        }
        public Produto AddProduto(ProdutoCreateDTO produtodto) {
            Produto produto = new Produto(produtodto.Nome, produtodto.Preco, produtodto.Estoque);
            if (produtodto.Imagem != null) {
                produto.Imagem = produtodto.Imagem;
            }
            _repos.Add(produto);
            return produto;
        }
        public ProdutoReadDTO GetProdutoById(int id) {
            Produto produto = _repos.GetById(id);
            if (produto == null) {
                return null;
            }
            ProdutoReadDTO produtoDTO = new ProdutoReadDTO {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                Imagem = produto.Imagem
            };
            return produtoDTO;
        }

        public List<ProdutoReadDTO> GetAllProdutos() {
            List<Produto> produtos = _repos.GetAll();
            List<ProdutoReadDTO> produtosDTO = produtos.Select(p => new ProdutoReadDTO {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Estoque = p.Estoque,
                Imagem = p.Imagem
            }).ToList(); ;
            return produtosDTO;
        }
        public ProdutoReadDTO UpdatePreco(int produtoId, decimal precoNovo) {
            Produto produto = _repos.GetById(produtoId);
            if (produto == null) {
                return null;
            }
            if (precoNovo < 0) {
                throw new ArgumentException("O preço não pode ser negativo.");
            }
            _repos.UpdatePreco(produto, precoNovo);
            ProdutoReadDTO produtoDTO = new ProdutoReadDTO {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = precoNovo,
                Estoque = produto.Estoque,
                Imagem = produto.Imagem
            }; ;
            return produtoDTO;
        }

        public ProdutoReadDTO UpdateQuantidade(int produtoId, int quantidadeAdicionada) {
            Produto produto = _repos.GetById(produtoId);
            if (produto == null) {
                return null;
            }
            if (quantidadeAdicionada < 0) {
                throw new ArgumentException("A quantidade a ser adicionada no estoque não pode ser negativo.");
            }
            _repos.UpdateEstoque(produto, quantidadeAdicionada);
            int estoqueNovo = (produto.Estoque + quantidadeAdicionada);
            ProdutoReadDTO produtoDTO = new ProdutoReadDTO {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Estoque = estoqueNovo,
                Imagem = produto.Imagem
            };
            return produtoDTO;
        }
        public FornecedorProduto AddProdutoToFornecedor(int fornecedorId, int produtoId) {
            FornecedorProduto fornecedorProduto = new FornecedorProduto(fornecedorId, produtoId);
            _repos.AddFornecedorProduto(fornecedorProduto);
            return fornecedorProduto;
        }
        public FornecedorProduto GetProdutoFornecedor(int fornecedorId, int produtoId) {
            FornecedorProduto fornecedorProduto = _repos.GetFornecedorProduto(fornecedorId, produtoId);
            if (fornecedorProduto == null) {
                return null;
            }
            return fornecedorProduto;
        }
        public List<FornecedorReadDTO> GetFornecedoresByIdProduto(int produtoId) {
            Produto produto = _repos.GetById(produtoId);
            if (produto == null) {
                return null;
            }
            List<FornecedorReadDTO> fornecedoresReadDTOs = _repos.GetAllFornecedoresByProdutoId(produtoId).Select(f => new FornecedorReadDTO {
                Id = f.Id,
                Nome = f.Nome
            }).ToList();
            return fornecedoresReadDTOs;
        }

        public bool RemoveFornecedorFromProduto(int fornecedorId, int produtoId) {
            FornecedorProduto fornecedorProduto = _repos.GetFornecedorProduto(fornecedorId, produtoId);
            if (fornecedorProduto == null) {
                return false;
            }
            _repos.RemoveFornecedorProduto(fornecedorProduto);
            return true;
        }

        public bool DeleteProduto(int id) {
            Produto produto = _repos.GetById(id);
            if (produto == null) {
                return false;
            }
            _repos.Delete(produto);
            return true;
        }
    }
}
