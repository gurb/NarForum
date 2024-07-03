using Api.Middleware;
using Application.Extensions;
using Persistence.Extensions;
using Identity.Extensions;
using Identity.Hubs;
using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR(options =>
{
    options.KeepAliveInterval = TimeSpan.FromSeconds(10); 
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(20);
});

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddWebSockets(o => { 
    o.AllowedOrigins.Add("https://localhost:7058");
    o.AllowedOrigins.Add("https://localhost:7212");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder
        .WithOrigins("https://localhost:7058", "https://localhost:7212")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()  // Eğer credential (kimlik doğrulama) kullanılıyorsa ekleyin.
        .SetIsOriginAllowed((host) => true) // CORS doğrulamasını özelleştirmek için gerekebilir.
    );
});

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.MapHub<TrackHub>("track", o => { 
    o.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
});

app.UseCors("all");
app.UseWebSockets();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
