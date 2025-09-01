using System.ComponentModel.DataAnnotations;

namespace BackendEstoque.Models
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }



        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Nome: {Nome}\n" +
                $"Quantidade: {Quantidade}\n" +
                $"deciamal: {Preco}";
        }
    }
}
