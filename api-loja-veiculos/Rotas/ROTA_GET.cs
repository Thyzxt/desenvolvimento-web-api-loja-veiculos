using Microsoft.EntityFrameworkCore;
using api_loja_veiculos.Models;
using api_loja_veiculos.Data;

namespace api_loja_veiculos.Rotas;

public static class ROTA_GET{
    public static void MapGetRoutes(this WebApplication app){
        app.MapGet("/api/veiculos", async (VeiculosContext context) => {
            var veiculosDisponiveis = await context.Veiculos
            .ToListAsync();

            return Results.Ok(veiculosDisponiveis);});

        app.MapGet("/api/veiculos/{placa}", async (VeiculosContext context, string placa) => {
            var veiculoEncontrado = await context.Veiculos
            .FindAsync(placa);

            return veiculoEncontrado != null ? Results.Ok(veiculoEncontrado) : Results
            .NotFound("Veículo não encontrado.");});

        app.MapGet("/api/veiculos/marcas", async (VeiculosContext context) => {
            var marcas = await context.Veiculos
                .Select(v => v.Marca)
                .Distinct()
                .ToListAsync();

            return Results.Ok(marcas);});

        app.MapGet("/api/veiculos/modelos", async (VeiculosContext context) => {
            var modelos = await context.Veiculos
                .Select(v => v.Modelo)
                .Distinct()
                .ToListAsync();

            return Results.Ok(modelos);});

        app.MapGet("/api/veiculos/modelos/marcas/{marca}", async (VeiculosContext context, string marca) => {
            var modelos = await context.Veiculos
                .Where(v => v.Marca == marca)
                .Select(v => v.Modelo)
                .Distinct()
                .ToListAsync();

            return Results.Ok(modelos);});

        app.MapGet("/api/veiculos/buscar", async (VeiculosContext context, string? q, string? marca, string? modelo) => {
            var consulta = context.Veiculos.AsQueryable();

            if(!string.IsNullOrWhiteSpace(q)){
                consulta = consulta.Where(v => 
                    v.Marca.Contains(q) || 
                    v.Modelo.Contains(q) || 
                    v.Placa.Contains(q));}

            if(!string.IsNullOrWhiteSpace(marca)){
                consulta = consulta.Where(v => v.Marca == marca);}

            if(!string.IsNullOrWhiteSpace(modelo)){
                consulta = consulta.Where(v => v.Modelo == modelo);}

            var resultados = await consulta.ToListAsync();

            return Results.Ok(resultados);});}}