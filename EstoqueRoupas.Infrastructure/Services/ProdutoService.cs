using EstoqueRoupas.Domain.Entities;
using EstoqueRoupas.Domain.Interfaces;
using EstoqueRoupas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EstoqueRoupas.Infrastructure.Services;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        return await _context.Produtos
            .AsNoTracking()
            .OrderBy(p => p.Nome)
            .ToListAsync();
    }

    public async Task<Produto?> ObterPorIdAsync(int id)
    {
        return await _context.Produtos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Produto> CriarAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task AtualizarAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto is null) return;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }
}
