using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Endpoint;
using AgentSecure.Interfaces;
using AgentSecure.Repositories;
using AgentSecure.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Enables legacy timestamp behavior (for compatibility with DateTime)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// ✅ Configure EF Core to use Npgsql with the connection string from appsettings.json or user secrets
builder.Services.AddDbContext<AgentSecureDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AgentSecure")));

// ✅ Set the JSON serializer to avoid circular reference issues
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// ✅ Add CORS policy to allow React frontend access
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React dev server
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddScoped<IAgentSecureCategoryRepository, AgentSecureCategoryRepository>();
builder.Services.AddScoped<IAgentSecureCategoryService, AgentSecureCategoryService>();
builder.Services.AddScoped<IAgentSecureLoginRepository, AgentSecureLoginRepository>();
builder.Services.AddScoped<IAgentSecureLoginService, AgentSecureLoginService>();
builder.Services.AddScoped<IAgentSecureUserRepository, AgentSecureUserRepository>();
builder.Services.AddScoped<IAgentSecureUserService, AgentSecureUserService>();
builder.Services.AddScoped<IAgentSecureVendorCategoryRepository, AgentSecureVendorCategoryRepository>();
builder.Services.AddScoped<IAgentSecureVendorCategoryService, AgentSecureVendorCategoryService>();
builder.Services.AddScoped<IAgentSecureVendorRepository, AgentSecureVendorRepository>();
builder.Services.AddScoped<IAgentSecureVendorService, AgentSecureVendorService>();


// ✅ Swagger / API docs setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply the CORS policy here (before mapping endpoints)
app.UseCors();

// Map endpoint groups (routes)
app.MapCategoryEndpoints();
app.MapLoginEndpoints();
app.MapUserEndpoints();
app.MapVendorCategoryEndpoints();
app.MapVendorEndpoints();

app.Run();
