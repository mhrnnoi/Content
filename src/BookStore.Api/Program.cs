using BookStore.Application;
using BookStore.Application.Mapping;
using BookStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer()
                    .AddApplication()
                    .AddInfruscture(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("database failure"))
                    .AddSwaggerGen();

}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}