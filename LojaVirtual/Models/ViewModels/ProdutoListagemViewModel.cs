﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace LojaVirtual.Models.ViewModels
{
    public class ProdutoListagemViewModel
    {

        public IPagedList<Produto> lista { get; set; }
        public List<SelectListItem> ordenacao
        {
            get
            {
                return new List<SelectListItem>() {
                    new SelectListItem("Alfabética", "A"),
                    new SelectListItem("Menor preço", "ME"),
                    new SelectListItem("Maior preço", "MA")
                };
            }
            private set { }
        }
    }
}