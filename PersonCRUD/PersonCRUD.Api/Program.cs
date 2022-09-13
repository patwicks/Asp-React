using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonCRUD.Application;
using PersonCRUD.Application.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PersonDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddMediatR(typeof(EntryPoint).Assembly);

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        build =>
        {
            build.WithOrigins("http://127.0.0.1:5174", "http://127.0.0.1:5173").AllowAnyMethod().AllowAnyHeader();
        }
        ));


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
