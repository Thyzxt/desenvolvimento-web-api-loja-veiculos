using Microsoft.EntityFrameworkCore;
using api_loja_veiculos.Data;
using api_loja_veiculos.Models;
using api_loja_veiculos.Rotas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VeiculosContext>(options =>
    options.UseSqlite("Data Source=veiculos.db"));

builder.Services.AddCors(options =>{
    options.AddPolicy("AllowAll", policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());});

var app = builder.Build();
app.UseCors("AllowAll");

app.MapGetRoutes();
app.MapDeleteRoutes();
app.MapPostRoutes();

PopularBancoDeDados(app);

app.Run();

void PopularBancoDeDados(WebApplication app){
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<VeiculosContext>();

    context.Database.Migrate(); 

    if(!context.Veiculos.Any()){
        var veiculosIniciais = new List<Veiculo>{
            new() { Placa = "ABC1234", Categoria = "Carro", Tipo = "Sedan", Marca = "Toyota", Ano = 2020, Modelo = "Corolla", Preco = 75000, Descricao = "TOYOTA COROLLA XEI 2.0 FLEX 177CV AUT./2020" },
            new() { Placa = "XYZ9876", Categoria = "Carro", Tipo = "Sedan", Marca = "Honda", Ano = 2018, Modelo = "Civic", Preco = 32000, Descricao = "HONDA CIVIC EXL 2.0 FLEX 155CV AUT./2018" },
            new() { Placa = "DEF5678", Categoria = "Carro", Tipo = "Hatch", Marca = "Ford", Ano = 2019, Modelo = "Fiesta", Preco = 48000, Descricao = "FORD FIESTA SE 1.6 FLEX 128CV MAN./2019" },
            new() { Placa = "GHI9012", Categoria = "Carro", Tipo = "Sedan", Marca = "Volvo", Ano = 2017, Modelo = "S60", Preco = 150000, Descricao = "VOLVO S60 T5 MOMENTUM 2.0 TURBO 254CV AUT./2017" },
            new() { Placa = "YZA4567", Categoria = "Carro", Tipo = "Hatch", Marca = "Hyundai", Ano = 2020, Modelo = "HB20", Preco = 58000, Descricao = "HYUNDAI HB20 VISION 1.6 FLEX 130CV AUT./2020" },
            new() { Placa = "JKL4321", Categoria = "Carro", Tipo = "Hatch", Marca = "Chevrolet", Ano = 2021, Modelo = "Onix", Preco = 65000, Descricao = "CHEVROLET ONIX LTZ 1.0 TURBO FLEX 116CV AUT./2021" },
            new() { Placa = "MNO6789", Categoria = "Carro", Tipo = "Hatch", Marca = "Toyota", Ano = 2019, Modelo = "Yaris", Preco = 42000, Descricao = "TOYOTA YARIS XL 1.3 FLEX 101CV MAN./2019" },
            new() { Placa = "PQR3456", Categoria = "Carro", Tipo = "Hatch", Marca = "Volkswagen", Ano = 2018, Modelo = "Golf", Preco = 67000, Descricao = "VOLKSWAGEN GOLF COMFORTLINE 1.0 TSI FLEX 128CV AUT./2018" },
            new() { Placa = "STU7890", Categoria = "Carro", Tipo = "Sedan", Marca = "Volkswagen", Ano = 2020, Modelo = "Jetta", Preco = 200000, Descricao = "VOLKSWAGEN JETTA R-LINE 1.4 TSI FLEX 150CV AUT./2020" },
            new() { Placa = "VWX1235", Categoria = "Carro", Tipo = "Hatch", Marca = "Renault", Ano = 2022, Modelo = "Sandero", Preco = 54000, Descricao = "RENAULT SANDERO ZEN 1.0 FLEX 82CV MAN./2022" },
            new() { Placa = "MOT1234", Categoria = "Moto", Tipo = "Street", Marca = "Yamaha", Ano = 2021, Modelo = "Factor 150", Preco = 14500, Descricao = "YAMAHA FACTOR 150 ED FLEX 2021" },
            new() { Placa = "MOT5678", Categoria = "Moto", Tipo = "Trail", Marca = "Honda", Ano = 2022, Modelo = "XRE 300", Preco = 28000, Descricao = "HONDA XRE 300 ABS 2022" },
            new() { Placa = "MOT4321", Categoria = "Moto", Tipo = "Custom", Marca = "Harley-Davidson", Ano = 2020, Modelo = "Iron 883", Preco = 52000, Descricao = "HARLEY DAVIDSON SPORTSTER IRON 883 2020" },
            new() { Placa = "MOT8765", Categoria = "Moto", Tipo = "Sport", Marca = "Kawasaki", Ano = 2021, Modelo = "Ninja 400", Preco = 29000, Descricao = "KAWASAKI NINJA 400 ABS 2021" },
            new() { Placa = "MOT9999", Categoria = "Moto", Tipo = "Scooter", Marca = "Honda", Ano = 2023, Modelo = "PCX 160", Preco = 18000, Descricao = "HONDA PCX 160 ABS 2023" },
            new() { Placa = "CAM1234", Categoria = "Caminhão", Tipo = "Truck", Marca = "Volvo", Ano = 2019, Modelo = "FH 540", Preco = 380000, Descricao = "VOLVO FH 540 6X4 TRUCK 2019" },
            new() { Placa = "CAM5678", Categoria = "Caminhão", Tipo = "Baú", Marca = "Mercedes-Benz", Ano = 2020, Modelo = "Accelo 1016", Preco = 220000, Descricao = "MERCEDES-BENZ ACCELO 1016 BAÚ 2020" },
            new() { Placa = "CAM4321", Categoria = "Caminhão", Tipo = "Cegonha", Marca = "Scania", Ano = 2021, Modelo = "R 450", Preco = 450000, Descricao = "SCANIA R 450 CEGONHA 2021" },
            new() { Placa = "CAM8765", Categoria = "Caminhão", Tipo = "Caçamba", Marca = "Volkswagen", Ano = 2018, Modelo = "Constellation", Preco = 280000, Descricao = "VW CONSTELLATION 26.280 6X4 CAÇAMBA 2018" },
            new() { Placa = "CAM9999", Categoria = "Caminhão", Tipo = "Baú", Marca = "Iveco", Ano = 2022, Modelo = "Tector 24-300", Preco = 310000, Descricao = "IVECO TECTOR 24-300 6X2 BAÚ 2022" }};

        context.Veiculos.AddRange(veiculosIniciais);
        context.SaveChanges();}}

