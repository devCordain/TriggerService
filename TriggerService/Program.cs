using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TriggerService.Application.Handlers;
using TriggerService.Application.Interfaces;
using TriggerService.Application.Services;
using TriggerService.Domain.Models;
using TriggerService.Infrastructure.Adapters;
using TriggerService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPropertyService, PropertyServiceAdapter>();
builder.Services.AddTransient<IOfficeService, OfficeServiceAdapter>();
builder.Services.AddTransient<IProgramService, ProgramServiceAdapter>();
builder.Services.AddTransient<IConditionValidationService, ConditionValidationService>();
builder.Services.AddTransient<IProgramTriggerRepository, ProgramTriggerRepository>();
builder.Services.AddTransient<IEventHandler<TriggerEvent>, TriggerEventHandler>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.SwaggerEndpoint("/swagger/v1/swagger.json", "Trigger Service V1");
    o.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();