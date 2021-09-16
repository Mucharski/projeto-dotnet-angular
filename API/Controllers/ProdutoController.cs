using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/produto")]

    public class ProdutoController : ControllerBase
    {

        private readonly DataContext _context;
        public ProdutoController(DataContext context)
        {
            _context = context;
        }
        //POST: api/produto/create
        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("", produto);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]

        public IActionResult List() => Ok(_context.Produtos.ToList());

        //GET : api/produto/getbyid/id
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // Busca pela chave primária
            Produto produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        //PUT: api/produto/update/{id}
        [HttpPut]
        [Route("update/{id}")]

        public IActionResult Update([FromBody] Produto produto)
        {

            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        //DELETE: api/produto/delete/{name}

        [HttpDelete]
        [Route("delete/{name}")]

        public IActionResult Delete([FromRoute] string name)
        {

            Produto produto = _context.Produtos.FirstOrDefault(
                produto => produto.Nome == name
            );

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(_context.Produtos.ToList());
        }

    }

}