using DemoResolution.Application.Command;
using DemoResolution.Domain.Interfaces;
using DemoResolution.Infraestructure.ResolutionFactories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateResolutionCommandHandler).Assembly));

builder.Services.AddScoped<IDocumentFactoryProvider, DocumentFactoryProvider>();
builder.Services.AddScoped<ResolutionJuryFactory>();

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
