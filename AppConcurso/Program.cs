using AppConcurso.Contexto;
using AppConcurso.Controllers;
using AppConcurso.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ConcursoController>();
builder.Services.AddScoped<CandidatoController>();
builder.Services.AddScoped<InscricaoController>();
builder.Services.AddScoped<ConcursoController>();
builder.Services.AddScoped<DisciplinaController>();
builder.Services.AddScoped<ConcursoDisciplinaController>();
builder.Services.AddScoped<PontuacaoController>();

string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexaoMySql");
builder.Services.AddDbContextPool<ContextoBD>(options => options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
