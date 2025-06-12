using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Endpoint;
using AgentSecure.Interfaces;
using AgentSecure.Repositories;
using AgentSecure.Services;
using AgentSecure.Helpers; // <-- required for EncryptionHelper

var builder = WebApplication.CreateBuilder(args);

// ✅ Enables legacy timestamp behavior (for compatibility with DateTime)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Configuration.AddUserSecrets<Program>();

// ✅ Configure EF Core to use Npgsql with the connection string from appsettings.json or user secrets
builder.Services.AddDbContext<AgentSecureDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AgentSecureDb")));

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

// ✅ Register services
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

// ✅ Print encrypted passwords (one-time use)
PrintEncryptedPasswords();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

// ✅ Map endpoint groups (routes)
app.MapCategoryEndpoints();
app.MapLoginEndpoints();
app.MapUserEndpoints();
app.MapVendorCategoryEndpoints();
app.MapVendorEndpoints();

app.Run();

// --- Add this method below app.Run() ---
static void PrintEncryptedPasswords()
{
    Console.WriteLine("🔐 Encrypted Sample Passwords:");
    var passwords = new Dictionary<string, string>
    {
        { "VikingPass1!", EncryptionHelper.Encrypt("VikingPass1!") },
        { "SandalsPass2@", EncryptionHelper.Encrypt("SandalsPass2@") },
        { "RoyalPass3#", EncryptionHelper.Encrypt("RoyalPass3#") },
        { "ApplePass4$", EncryptionHelper.Encrypt("ApplePass4$") },
        { "DisneyPass5%", EncryptionHelper.Encrypt("DisneyPass5%") },
        { "DeltaPass6^", EncryptionHelper.Encrypt("DeltaPass6^") },
        { "GlobusPass7&", EncryptionHelper.Encrypt("GlobusPass7&") },
        { "TiPass8*", EncryptionHelper.Encrypt("TiPass8*") },
        { "ExpediaPass9(", EncryptionHelper.Encrypt("ExpediaPass9(") },
        { "AmrPass10)", EncryptionHelper.Encrypt("AmrPass10)") },
    };

    foreach (var pair in passwords)
    {
        Console.WriteLine($"{pair.Key} => {pair.Value}");
    }
}
