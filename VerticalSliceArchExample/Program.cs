using VerticalSliceArchExample.Behaviors.Filters;
using VerticalSliceArchExample.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<FluentValidationExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

ApplicationServicesExtensions.AddApplicationServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
