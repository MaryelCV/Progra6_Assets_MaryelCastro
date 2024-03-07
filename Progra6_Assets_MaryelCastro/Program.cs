using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Progra6_Assets_MaryelCastro.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //Ac� agregamos los valores de conexi�n a la base de da6tos para nuestra applicaci�n 

        //1. agregar la info en una una etiqueta en el archivo appsettins.json 

        var CnnStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("CNNSTR")
            );

        //por seguridad es mejor agregar la info de la contrase�a en este c�digo o 
        //podr�mos tener un almacen externo. 
        //Investigar qu� son los User Secrets
        CnnStrBuilder.Password = "progra6";

        //ahora que hemos extraido la info de la cadena de conexi�n 
        //creamos una variable tipo string que la almacene 
        string CnnStr = CnnStrBuilder.ConnectionString;

        //ahora conectamos el proyecto a la base de datos 
        builder.Services.AddDbContext<Progra620241Context>(options => options.UseSqlServer(CnnStr));



        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}