using Microsoft.EntityFrameworkCore;
using PortalAboutEverything.Controllers;
using PortalAboutEverything.CustomMiddlewareServices;
using PortalAboutEverything.Data;
using PortalAboutEverything.Helpers;
using PortalAboutEverything.Hubs;
using PortalAboutEverything.Mappers;
using PortalAboutEverything.Services;
using PortalAboutEverything.Services.Apis;
using PortalAboutEverything.Services.AuthStuff;
using PortalAboutEverything.Services.AuthStuff.Interfaces;
using PortalAboutEverything.Services.BackgroundServices;
using PortalAboutEverything.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(p =>
    {
        p.AllowAnyMethod();
        p.AllowAnyOrigin();
        p.AllowAnyHeader();
    });
});

builder.Services
    .AddAuthentication(AuthController.AUTH_METHOD)
    .AddCookie(AuthController.AUTH_METHOD, option =>
    {
        option.LoginPath = "/Auth/Login";
        option.AccessDeniedPath = "/Auth/AccessDenied";
    });

builder.Services.AddDbContext<PortalDbContext>(x => x.UseSqlServer(PortalDbContext.CONNECTION_STRING));

//Repository

var autoRegistrator = new AutoRegistrator();
autoRegistrator.RegiterRepositories(builder.Services);
autoRegistrator.RegiterRepositoriesByInterface(builder.Services);


// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<AlertMapper>();
builder.Services.AddScoped<MovieMapper>();

builder.Services.AddSingleton<IPathHelper, PathHelper>();
builder.Services.AddSingleton<PathHelper>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSignalR();

builder.Services.AddHttpClient<HttpChatApiService>(
    x => x.BaseAddress = new Uri("https://localhost:7072/"));
builder.Services.AddHttpClient<HttpApiKittyService>(
    t => t.BaseAddress = new Uri("https://api.thecatapi.com"));
builder.Services.AddHttpClient<HttpApiJoke>(
    t => t.BaseAddress = new Uri("https://official-joke-api.appspot.com/"));
builder.Services.AddHttpClient<HttpMoviesAverageRateApiService>(
    x => x.BaseAddress = new Uri("https://localhost:58814/"));
builder.Services.AddHttpClient<HttpApiSpellService>(
    x => x.BaseAddress = new Uri("https://potterapi-fedeperin.vercel.app/"));

builder.Services.AddHostedService<ImageGenerator>();
builder.Services.AddSingleton<ImageGenerationQueueService>();

var app = builder.Build();

//app.UseMiddleware<MyGlobalHandlerException>();

var seed = new Seed();
seed.Fill(app.Services);

app.UseCors();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Who I am?
app.UseAuthorization(); // May I?

app.UseMiddleware<LocalizationMiddleware>();

app.MapHub<ChatHub>("/hubs/chat");
app.MapHub<MovieHub>("/hubs/movie");
app.MapHub<AlertHub>("/hubs/alert");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

app.Run();
