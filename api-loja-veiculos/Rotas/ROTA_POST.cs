using api_loja_veiculos.Models;
using api_loja_veiculos.Data;

namespace api_loja_veiculos.Rotas;

public static class ROTA_POST{
    public static void MapPostRoutes(this WebApplication app){
        app.MapPost("/api/veiculos", async (Veiculo veiculo, VeiculosContext context) => {
            var veiculoExistente = await context.Veiculos
            .FindAsync(veiculo.Placa);

            if(veiculoExistente != null){

                return Results.Conflict($"Veículo com placa {veiculo.Placa} já existe.");}

            context.Veiculos.Add(veiculo);
            await context.SaveChangesAsync();

            return Results.Created($"/veiculos/{veiculo.Placa}", veiculo);});}}