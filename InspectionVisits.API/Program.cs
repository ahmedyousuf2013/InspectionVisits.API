using InspectionVisits.API;
using InspectionVisits.Application;
using InspectionVisits.Application.Commands;
using InspectionVisits.Application.Commands.CreatOrUpdateEntityToInspect;
using InspectionVisits.Application.Profiles;
using InspectionVisits.Domain;
using InspectionVisits.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowCros", policy =>
    {
        policy.WithOrigins(builder.Configuration["AllowedHosts"])
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();




builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InspectionVisits API", Version = "v1" });

    // 🧠 تعريف الـ Security Scheme (Bearer Token)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field. Example: Bearer {token}",
        Name = "Bearer",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // 🧠 تفعيل الـ Authorization في Swagger
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] { }
        }
    });
});

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
     .WriteTo.Console()

     .ReadFrom.Configuration(context.Configuration));
// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Authentication + Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

builder.Services.AddAuthorization();

// Application services
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreatOrUpdateEntityToInspectCommand).Assembly));

var app = builder.Build();

app.UseExceptionHandler();

app.UseCors("allowCros");
app.UseMiddleware<JwtValidationMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


    var roleManager = app.Services.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

if (!await roleManager.RoleExistsAsync(Constants.Roles.Admin))
    await roleManager.CreateAsync(new IdentityRole(Constants.Roles.Admin));

if (!await roleManager.RoleExistsAsync(Constants.Roles.Inspector))
    await roleManager.CreateAsync(new IdentityRole(Constants.Roles.Inspector));

var userManager = app.Services.CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

if (!await userManager.Users.AnyAsync(x => x.UserName == "admin"))
{
    var user = await userManager.CreateAsync(new ApplicationUser { UserName = "admin" }, "P@ssw0rd");

    await userManager.AddToRoleAsync(new ApplicationUser { UserName = "admin", Email = "admin@gmail.com" }, Constants.Roles.Admin);
}

app.Run();
