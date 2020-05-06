﻿using LojaVirtual.Libraries.CarrinhoCompra;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private CarrinhoCompra _carrinhoCompra;
        private IProdutoRepository _produtoRepository;
        public CarrinhoCompraController(CarrinhoCompra carrinhoCompra, IProdutoRepository produtoRepository)
        {
            _carrinhoCompra = carrinhoCompra;
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarItem(int id)
        {
            Produto produto = _produtoRepository.ObterProduto(id);
            if (produto == null)
            {
                //TODO - Produto nao existe no banco - msg de erro
                return View();
            }
            else
            {
                var item = new Item() { Id = id, Quantidade = 1 };
                _carrinhoCompra.Cadastrar(item);

                return RedirectToAction(nameof(Index));
            }

        }
        public IActionResult AlterarQuantidade()
        {
            return View();
        }

        public IActionResult RemoverItem()
        {
            return View();
        }
    }
}