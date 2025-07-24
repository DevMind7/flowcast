using flowcast.Application.Engine;
using flowcast.Application.Repository;
using flowcast.Domain.Interfaces;
using flowcast.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<WorkflowRepository>();
builder.Services.AddScoped<WorkflowEngine>();

builder.AddNpgsqlDbContext<FlowcastDbContext>(connectionName: "flowcastDb");

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //using (var scope = app.Services.CreateScope())
    //{
    //    var context = scope.ServiceProvider.GetRequiredService<FlowcastDbContext>();
    //    context.Database.EnsureCreated();
    //    var strat = context.Database.CreateExecutionStrategy();
    //    strat.Execute(() => context.Database.Migrate());
    //}
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapDefaultEndpoints();
app.MapControllers();


app.Run();

