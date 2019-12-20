﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index()
        {
            List<Categoria> categorias = _categoriaRepository.ObterTodasCategorias().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Categoria categoria)
        {
            //TODO: Implementar
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            //TODO: Implementar
            return View();
        }
        [HttpPost]
        public IActionResult Atualizar([FromForm]Categoria categoria)
        {
            //TODO: Implementar
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            return View();
        }

    }
}