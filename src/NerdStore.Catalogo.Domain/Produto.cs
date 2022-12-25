using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor,
            Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            Validar();
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            if (categoria is null) throw new DomainException("A categoria vinculada ao produto não pode ser nula");
            if (categoria.Id == Guid.Empty) throw new DomainException("O campo ID da categoria do produto não pode estar vazio");
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(Descricao)) throw new DomainException("O campo Descricao do produto não pode estar vazio");
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            if(string.IsNullOrEmpty(Nome)) throw new DomainException("O campo Nome do produto não pode estar vazio");
            if(string.IsNullOrEmpty(Descricao)) throw new DomainException("O campo Descricao do produto não pode estar vazio");
            if(CategoriaId == Guid.Empty) throw new DomainException("O campo CategoriaId do produto não pode estar vazio");
            if(Valor <= 0) throw new DomainException("O campo Valor do produto não pode ser menor ou igual a 0");
            if(string.IsNullOrEmpty(Imagem)) throw new DomainException("O campo Imagem do produto não pode estar vazio");
        }
    }
}