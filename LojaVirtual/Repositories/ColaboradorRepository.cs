﻿using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Models.Constants;
using LojaVirtual.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private IConfiguration _conf;
        private LojaVirtualContext _banco;

        public ColaboradorRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Atualizar(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Colaborador cliente = ObterColaborador(Id);
            _banco.Remove(cliente);
            _banco.SaveChanges();
        }

        public Colaborador Login(string Email, string Senha)
        {
            Colaborador colaborador = _banco.Colaboradores.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return colaborador;
        }

        public Colaborador ObterColaborador(int Id)
        {
            return _banco.Colaboradores.Find(Id);
        }

        public IPagedList<Colaborador> ObterTodosColaboradores(int? pagina)
        {
            int numeroPagina = pagina ?? 1;
            return _banco.Colaboradores.Where(a => a.Tipo != ColaboradorTipoConstant.Gerente).ToPagedList<Colaborador>(numeroPagina, _conf.GetValue<int>("RegistrosPorPagina"));
            
        }
    }
}
