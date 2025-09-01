using BackendEstoque.Data;
using BackendEstoque.Models;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BackendEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly  AppDbContext _context;
        public ProdutoController(AppDbContext context) 
        {
            _context=context;
        }


        [HttpGet(Name = "ProdutosGet")]
        public async Task<IEnumerable<Produto>> Get() 
        {
            return await _context.Produtos.ToListAsync();
        }


        [HttpPost(Name = "CriarProduto")]
        public async Task<IActionResult> Post([FromBody] Produto novoProduto)
        {
            if (novoProduto == null)
                return BadRequest("Produto inválido.");

            novoProduto.Id = Guid.NewGuid();
            _context.Produtos.Add(novoProduto); // Adiciona no banco
            await _context.SaveChangesAsync();  //persiste no banco

            return CreatedAtAction(nameof(Post), new { Id = novoProduto.Id }, novoProduto);
                
        }

        [HttpDelete(Name ="DeleteProduto")]
        public async Task<ActionResult<Produto>> Delete([FromBody] Produto DellProduto)
        {
            var Produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Nome == DellProduto.Nome);

            if (Produto == null)
                return NotFound();

            _context.Remove(Produto);
            _context.SaveChanges();

            return Ok("Produto deletado com sucesso!");

        }

        [HttpPut(Name = "UpdateProduto")]
        public async Task<ActionResult<Produto>> Put(string Nome, [FromBody] Produto atualizaProduto)
        {
            //BUSCO PRODUTO NO BANCO
            var getProdutoBanco = await _context.Produtos.FirstOrDefaultAsync(x => x.Nome == Nome);

            if (getProdutoBanco == null)
                return NotFound();

            //SUBSTITUINDO OS VALORES do PRODUTO DO ESTOQUE PELO O DO IMPUT
            getProdutoBanco.Nome  =  atualizaProduto.Nome;
            getProdutoBanco.Quantidade = atualizaProduto.Quantidade;
            getProdutoBanco.Preco = atualizaProduto.Preco;

            //NAO SE USA ADD NO PUT POIS ELE ACABA ADICIONANDO AO INVEZ DE ATUALIZAR
            //_context.Add(getProdutoBanco);

            await _context.SaveChangesAsync();

            return Ok($"{atualizaProduto}\nProduto Atualizado!" );
        }






        
    }
}
