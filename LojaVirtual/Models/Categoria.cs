﻿using LojaVirtual.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Categoria
    {
        [Display(Name = "Código")]
        public int Id { get; set; }     
        
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(2, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        //TODO - Criar validação - Nome Categoria Unico no banco de dados.
        public string Nome { get; set; }

        /*
         * www.lojavirtual.com.br/categoria/5
         * www.lojavirtual.com.br/categoria/informatica (url amigável)
         * 
         * Exemplo de Slug: 
         *  Nome: Telefone sem fio
         *  Slug: telefone-sem-fio         
         */

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(2, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Slug { get; set; }

        /*
         * Auto-relacionamento
         * 1-Informatica - Pai:null
         *  2- Mouse - Pai:1
         *      3- Mouse sem fio - Pai:2
         *      4- Mouse Gamer - Pai:3
         */

        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }
        
        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }

    }
}
