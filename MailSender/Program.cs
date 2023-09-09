using Autofac.Core;
using MailSender.Core.Repositories;
using MailSender.Core.Services;
using MailSender.Core.UnitOFWork;
using MailSender.Repository;
using MailSender.Repository.Repositories;
using MailSender.Repository.UnitOfWork;
using MailSender.Service.Mapping;
using MailSender.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Database ba�lant�s�n� y�nlendirmek i�in tan�mland� 
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        //  options.MigrationsAssembly("NLayer.Reporsitory")    �eklinde kullan�la bilir fakar bu tip g�vensiz oldu�u i�in generic bir �ekilde yakla��yoruz

        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// �nterfaceler ile S�n�flar aras�ndaki Ba�lant�y� tan�mlad�k
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(service<>));

builder.Services.AddScoped<ISendedMailRepository, SendedMailRepostory>();
builder.Services.AddScoped<ISendedMailService, SendedMailService>();


//Mapping i�lemleri buradan tan�mlad�k 
builder.Services.AddAutoMapper(typeof(MapProfile));

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
