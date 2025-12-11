
using ColorPaletteBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace ColorPaletteBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //
            builder.Services.AddDbContext<ColorDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration["db:conn"]);
            });
            //

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //
            builder.Services.AddCors();

            if (builder.Environment.IsProduction())
            {
                builder.WebHost.ConfigureKestrel(options =>
                {
                    options.ListenAnyIP(int.Parse(builder.Configuration["settings:port"] ?? "6500"));
                });
            }
            //

            var app = builder.Build();

            //
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ColorDbContext>();
                dbContext.Database.EnsureCreated();
            }
            //

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //
            app.UseCors(t => t
                .WithOrigins(builder.Configuration["settings:frontend"] ?? "http://localhost:4200")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod());
            //

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
