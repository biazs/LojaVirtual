using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        /*
         * www.lojavirtual.com.br/categoria/5
         * www.lojavirtual.com.br/categoria/informatica (url amigável)
         * 
         * Exemplo de Slug: 
         *  Nome: Telefone sem fio
         *  Slug: telefone-sem-fio         
         */

        public string Slug { get; set; }

        /*
         * Auto-relacionamento
         * 1-Informatica - Pai:null
         *  2- Mouse - Pai:1
         *      3- Mouse sem fio - Pai:2
         *      4- Mouse Gamer - Pai:3
         */

        public int? CategoriaPaiId { get; set; }

        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }


    }
}
