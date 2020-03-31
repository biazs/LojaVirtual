using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace LojaVirtual.Models.ViewModels
{
    public class IndexViewModel
    {
        public NewsletterEmail newsletter { get; set; }
        public IPagedList<Produto> lista { get; set; }
        public List<SelectListItem> ordenacao
        {
            get
            {
                return new List<SelectListItem>() {
                    new SelectListItem("Alfabetica", "A"),
                    new SelectListItem("Menor preço", "ME"),
                    new SelectListItem("Maior preço", "MA"),
                };
            }
            private set { }
        }

    }
}
