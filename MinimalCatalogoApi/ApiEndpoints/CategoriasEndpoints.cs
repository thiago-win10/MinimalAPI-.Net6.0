using Microsoft.EntityFrameworkCore;
using MinimalCatalogoApi.Context;
using MinimalCatalogoApi.Models;

namespace MinimalCatalogoApi.ApiEndpoints
{
    public static class CategoriasEndpoints
    {
        public static void MapCategoriasEndpoints(this WebApplication app)
        {

            //Endpoints Categorias

            //Método para Criar Categorias
            app.MapPost("/categorias", async (Categoria categoria, AppDbContext db)
                =>
            {
                db.Categorias.Add(categoria);
                await db.SaveChangesAsync();

                return Results.Created($"/categorias/{categoria.CategoriaId}", categoria);

            });

            //Método para buscar a lista de todas as categorias
            app.MapGet("/categorias", async (AppDbContext db)
                => await db.Categorias.ToListAsync()).RequireAuthorization();


            //Método para retornar apenas uma categoria pelo seu id
            app.MapGet("/categorias/{id:int}", async (int id, AppDbContext db)
                =>
            {
                return await db.Categorias.FindAsync(id)
                is Categoria categoria
                ? Results.Ok(categoria)
                : Results.NotFound("Categoria não encontrada.");
            });

            //Método para atualizar uma categoria pelo seu id
            app.MapPut("/categorias/{id:int}", async (int id, Categoria categoria, AppDbContext db)
                =>
            {
                if (categoria.CategoriaId != id)
                {
                    return Results.BadRequest();
                }

                var categoriaDB = await db.Categorias.FindAsync(id);
                if (categoriaDB is null) return Results.NotFound();

                categoriaDB.Nome = categoria.Nome;
                categoriaDB.Descricao = categoria.Descricao;

                await db.SaveChangesAsync();
                return Results.Ok(categoriaDB);
            });

            //Método para Deletar uma categoria pelo seu id
            app.MapDelete("/categorias/{id:int}", async (int id, AppDbContext db)
                =>
            {

                var categoria = await db.Categorias.FindAsync(id);
                if (categoria is null)
                {
                    return Results.NotFound("Categoria não encontrada.");
                }

                db.Categorias.Remove(categoria);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

        }
    }
       
       
}
