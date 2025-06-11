using api_loja_veiculos.Models;
using Microsoft.EntityFrameworkCore;
using api_loja_veiculos.Data;

namespace api_loja_veiculos.Rotas;

public static class ROTA_DELETE{
    public static void MapDeleteRoutes(this WebApplication app){
        app.MapDelete("/api/veiculos/{placa}", async (string placa, VeiculosContext context) => {
            var veiculoParaDeletar = await context.Veiculos
            .FindAsync(placa);

            if(veiculoParaDeletar is null){
                return Results.NotFound("Veículo não encontrado.");}

            context.Veiculos.Remove(veiculoParaDeletar);
            await context.SaveChangesAsync();
            return Results.Ok($"Veículo com placa {placa} removido com sucesso.");});}}