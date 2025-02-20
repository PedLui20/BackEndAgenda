
using AppAgenda.Api.Endpoints;
using AppAgenda.Infraestructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("CORSPolicy",
//         b => b
//             .WithOrigins("http://localhost:4200") // Cambia esto por la URL de tu frontend en producción
//             .AllowAnyMethod()
//             .AllowAnyHeader()
//             .AllowCredentials()
//             .SetIsOriginAllowed((hosts) => true));
// });
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        b => b
            .WithOrigins("http://localhost:4200") // Cambia esto por la URL de tu frontend en producción
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services
    .RegisterDataBase(builder.Configuration)
    .RegisterRepositories()
    .RegisterServices();

var app = builder.Build();

app.UseCors("CORSPolicy");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIS SUINT-ACADEMIC V.1.0");
    c.RoutePrefix = "swagger";
    c.EnableFilter();
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapUsuarioEndpoint();
app.MapEventoEndpoint();

app.Run();
