using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayerApp.Core.Repositories;
using NLayerApp.Core.Services;
using NLayerApp.Core.UnitOfWorks;
using NLayerApp.Repository;
using NLayerApp.Repository.Repositories;
using NLayerApp.Repository.UnitOfWorks;
using NLayerApp.Service.Mapping;
using NLayerApp.Service.Services;
using NLayerApp.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options => // filterimizi b?t?n controller lara ekliyoruzekliyoruz
    {
        options.Filters.Add(new ValidateFilterAttribute());
    }
    ).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
// default validation ? kapat?yoruz
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter=true;
});





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});






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
