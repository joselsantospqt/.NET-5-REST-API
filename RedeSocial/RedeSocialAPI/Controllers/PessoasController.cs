﻿using Domain.Entidade;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RedeSocialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private PessoaService _Service;

        public PessoasController(PessoaService service)
        {
            _Service = service;
        }


        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var getAllPessoa = _Service.GetAll();

            return Ok(getAllPessoa);
        }



        [HttpGet("{id:Guid}")]
        public ActionResult GetById([FromRoute] Guid id)
        {

            var pessoa = _Service.GetPessoa(id);

            if (pessoa == null)
                return NoContent();

            return Ok(pessoa);
        }

        [HttpPost]
        public ActionResult Pessoa([FromBody] Pessoa create)
        {

            var pessoa = _Service.CreatePessoa(create.Nome, create.Sobrenome, create.DataNascimento, create.Email, create.Senha);

            return Created("api/[controller]", pessoa);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {

            _Service.DeletePessoa(id);

            return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, Pessoa update)
        {

            var updatePessoa = _Service.UpdatePessoa(id, update.Nome, update.Sobrenome, update.DataNascimento, update.Email, update.Senha);

            return Ok(updatePessoa);

        }


    }
}
