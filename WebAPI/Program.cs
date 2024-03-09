using Application.Services;
using Domain.Abstractions;
using Infrasctructure;
using Infrasctructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

            builder.Services.AddControllers()
                .AddApplicationPart(presentationAssembly);

            // builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add-migration init -context FinPortDbContext -startupproject WebAPI -verbose
            // update-database -context FinPortDbContext -startupproject WebAPI -verbose
            builder.Services.AddDbContextPool<FinPortDbContext>(
            options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(FinPortDbContext)));
            });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Application.AssemblyReference).Assembly));

            builder.Services.AddScoped<INoteRepository, NoteRepository>();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            builder.Services.AddScoped<ITransactionTypeService, TransactionTypeService>();

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
