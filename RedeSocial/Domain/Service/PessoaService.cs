﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidade;
using static System.String;
using static System.Guid;
using Domain.Repositorio;

namespace Domain.Service
{
    public class PessoaService
    {
        private IRepositorioPessoa RepositorioPessoa { get; }

        public PessoaService(IRepositorioPessoa repositorioPessoa)
        {
            RepositorioPessoa = repositorioPessoa;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return RepositorioPessoa.GetAll();
        }
        public Pessoa GetPessoa(Guid id)
        {
            return RepositorioPessoa.GetById(id);
        }

        //IMPLEMENTAR MAIS PARA FRENTE
        //public Pessoa GetAuthor(string author)
        //{
        //    if (IsNullOrWhiteSpace(author))
        //    {
        //        return db.Pessoa.Find(author);
        //    }

        //    return db.Pessoa.Where(x => x.Author == author).FirstOrDefault();

        //}

        public Pessoa CreatePessoa(string nome,
            string sobrenome, 
            DateTime dataDeNascimento, 
            string email, string senha
           )
        {

            var Pessoa = new Pessoa();
            Pessoa.Id = NewGuid();
            Pessoa.Nome = nome;
            Pessoa.Sobrenome = sobrenome;
            Pessoa.DataNascimento = dataDeNascimento;
            Pessoa.Email = email;
            Pessoa.Senha = senha;
            Pessoa.UpDateTime = new DateTime(); 

            RepositorioPessoa.Save(Pessoa);

            return Pessoa;
        }

        public Pessoa UpdatePessoa(Guid id,
            string nome,
            string sobrenome,
            DateTime dataDeNascimento,
            string email, string senha)
        {

            var Pessoa = RepositorioPessoa.GetById(id);

            Pessoa.Nome = nome;
            Pessoa.Sobrenome = sobrenome;
            Pessoa.DataNascimento = dataDeNascimento;
            Pessoa.Email = email;
            Pessoa.Senha = senha;
            Pessoa.UpDateTime = DateTime.UtcNow;

            RepositorioPessoa.Update(Pessoa);

            return Pessoa;
        }


        public void DeletePessoa(Guid id)
        {
            RepositorioPessoa.Remove(id);
        }


    }
}
