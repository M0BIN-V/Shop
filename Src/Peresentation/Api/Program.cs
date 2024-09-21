var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, typeof(Program).Assembly);

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAnyOrigin");

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();