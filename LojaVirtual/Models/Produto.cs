﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name="Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        //frete - correios
        public double Peso { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }

        /*
         * EF - ORM - Biblioteca Unir - Banco de dados e POO (ORM - Mapeamento de Objetos <-> Relacionamento)
         * Fluente API - Attributes
        */

        //Banco de dados - Relacionamento entre tabelas
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        //POO - Associação entre objetos
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }
    }
}
