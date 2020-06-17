using System.ComponentModel.DataAnnotations.Schema;
using LojaVirtual.Models.ProdutoAgregador;

namespace LojaVirtual.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Caminho { get; set; }
        //Banco de dados
        public int ProdutoId { get; set; }

        //POO
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
    }
}
