using Microsoft.EntityFrameworkCore;
using NutritionistPreview.Api.Extension;
using NutritionistPreview.Api.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetSecrets();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Context
builder.Services.AddDbContext<NutritionistContext>(options =>
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionString:DefaultConnection").Value));
#endregion

#region Dependency Inject
builder.Services.AddSingletons();
builder.Services.AddScopeds();
#endregion

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
