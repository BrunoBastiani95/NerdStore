using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade =  profundidade;

            Validacao();
        }

        public void Validacao()
        {
            if (Altura <= 0) throw new DomainException("O campo Altura não pode ser menor ou igual a 0");
            if (Largura <= 0) throw new DomainException("O campo Largura não pode ser menor ou igual a 0");
            if (Profundidade <= 0) throw new DomainException("O campo Profundidade não pode ser menor ou igual a 0");
        }

        public string DescricaoFormatada() => $"LxAxP: {Largura} x {Altura} x {Profundidade}";
    }
}