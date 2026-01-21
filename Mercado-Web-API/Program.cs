
using Mercado_Web_API.Data;
using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.Data.RepositoryEF;
using Mercado_Web_API.Service;
using Microsoft.EntityFrameworkCore;

namespace Mercado_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MercadoContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("MercadoAPIDatabase")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IClienteRepository, ClienteRepositoryEF>();
            builder.Services.AddScoped<IFornecedorRepository, FornecedorRepositoryEF>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepositoryEF>();

            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IFornecedorService, FornecedorService>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
