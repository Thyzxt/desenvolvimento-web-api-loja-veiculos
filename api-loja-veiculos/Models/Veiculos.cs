using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_loja_veiculos.Models;

public class Veiculo{

    [Key]
    public string Placa { get; set; }

    public string Categoria { get; set; }

    public string Descricao { get; set; }

    public string Tipo { get; set; }

    public string Marca { get; set; }

    public int Ano { get; set; }

    public string Modelo { get; set; }

    public decimal Preco { get; set; }}