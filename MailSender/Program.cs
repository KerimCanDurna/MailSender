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


//Database baðlantýsýný yönlendirmek için tanýmlandý 
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        //  options.MigrationsAssembly("NLayer.Reporsitory")    Þeklinde kullanýla bilir fakar bu tip güvensiz olduðu için generic bir þekilde yaklaþýyoruz

        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// Ýnterfaceler ile Sýnýflar arasýndaki Baðlantýyý tanýmladýk
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(service<>));

builder.Services.AddScoped<ISendedMailRepository, SendedMailRepostory>();
builder.Services.AddScoped<ISendedMailService, SendedMailService>();


//Mapping iþlemleri buradan tanýmladýk 
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
