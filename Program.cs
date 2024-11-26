using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Sorveteria.Configs.Automapper;
using Sorveteria.Repositories.Pedidos;
using Sorveteria.Repositories.Sabores;
using Sorveteria.Repositórios.Authentication;
using System.Text;
using static Sorveteria.Contexts.ApplicationContext;

try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<ApplicationDbContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
    });
    // builder.Services.AddCors(options => {
    //     options.AddDefaultPolicy(
    //         policy => {
    //             policy.WithOrigins("http://localhost:4200", "http://localhost:5000");
    //         }
    //     );
    // });
    builder.Services.AddCors(options =>
    {
        // this defines a CORS policy called "default"
        options.AddPolicy("default", policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
    builder.Services.AddSerilog();
    builder.Services.AddMvc();
    builder.Services.AddControllers(option => {
    }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
    builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
    builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
    builder.Services.AddScoped<ISaboresRepository, SaboresRepository>();
    builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
    builder.Services.AddAutoMapper(typeof(MappingConfig));
    var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
        x.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
                if (token == null || token == "null")
                {
                    context.NoResult();
                    return Task.CompletedTask;
                }
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenMalformedException))
                {
                    context.NoResult();
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "text/plain";
                    return context.Response.WriteAsync("Invalid token.");
                }
                return Task.CompletedTask;
            }
        };
    });
    // builder.Services.AddAuthorization();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    // builder.Services.AddControllers();
    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseHttpsRedirection();
    }
    app.UseCors("default");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
catch (Exception ex)
{
    // TODO
    throw ex;
}