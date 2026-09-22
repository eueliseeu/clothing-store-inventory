using EstoqueRoupas.Domain.Entities;
using EstoqueRoupas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueRoupas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> ObterTodos()
    {
        var produtos = await _produtoService.ObterTodosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>> ObterPorId(int id)
    {
        var produto = await _produtoService.ObterPorIdAsync(id);

        if (produto is null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> Criar([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var novoProduto = await _produtoService.CriarAsync(produto);

        return CreatedAtAction(nameof(ObterPorId), new { id = novoProduto.Id }, novoProduto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produto)
    {
        if (id != produto.Id)
            return BadRequest("O Id da URL não confere com o Id do corpo.");

        var existente = await _produtoService.ObterPorIdAsync(id);
        if (existente is null)
            return NotFound();

        await _produtoService.AtualizarAsync(produto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id)
    {
        var existente = await _produtoService.ObterPorIdAsync(id);
        if (existente is null)
            return NotFound();

        await _produtoService.RemoverAsync(id);
        return NoContent();
    }
}
