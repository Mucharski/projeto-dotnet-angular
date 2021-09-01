using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Produto Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]

        public List<Produto> List() => _context.Produtos.ToList();

        //PUT: api/produto/update/{id}
        [HttpPut]
        [Route("update/{id}")]

        public async Task<IActionResult> Update(long id, Produto produto)
        {

            if (id != produto.Id)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/produto/delete/{id}

        [HttpDelete]
        [Route("delete/{id}")]

        public async Task<IActionResult> Delete(int id)
        {

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}