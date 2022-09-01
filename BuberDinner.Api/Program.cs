using BuberDinner.Api.Filter;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
